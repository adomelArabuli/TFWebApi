namespace TFWebApi.Middleware
{
	public class RequestLoggingMiddleware
	{
		private readonly RequestDelegate _next;

		public RequestLoggingMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			var request = context.Request;

            await Console.Out.WriteLineAsync($"Request: {request.Method} {request.Path}");

			await _next(context);

			var response = context.Response;
            await Console.Out.WriteLineAsync($"Response: {response.StatusCode}");
        }
	}
}
