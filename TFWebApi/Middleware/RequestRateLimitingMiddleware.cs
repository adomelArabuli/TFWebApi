namespace TFWebApi.Middleware
{
	public class RequestRateLimitingMiddleware
	{
		private readonly RequestDelegate _next;
		private static readonly Dictionary<string, (DateTime timeStamp, int count)> _request = new();
		public RequestRateLimitingMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			var ip = context.Connection.RemoteIpAddress?.ToString();
			if (ip != null)
			{
				if (_request.ContainsKey(ip))
				{
					var(timestamp, count) = _request[ip];
					if(timestamp.AddMinutes(1) > DateTime.Now)
					{
						if(count > 10) 
						{
							context.Response.StatusCode = StatusCodes.Status429TooManyRequests;
							await context.Response.WriteAsync("Request limits per minute exceeded");
							await Console.Out.WriteLineAsync("Request limits per minute exceeded");
							return;
						}
						_request[ip] = (timestamp, count + 1);
					}
                    else
                    {
						_request[ip] = (DateTime.Now, 1);
                    }
                }
				else
				{
					_request[ip] = (DateTime.Now, 1);
				}
			}
			await _next(context);
		}
	}
}
