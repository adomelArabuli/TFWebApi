namespace TFWebApi.Middleware
{
	public class CustomAuthenticationMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly IConfiguration _configuration;
		public CustomAuthenticationMiddleware(RequestDelegate next, IConfiguration configuration)
		{
			_next = next;
			_configuration = configuration;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			var apiKeyFromHeader = context.Request.Headers["x-api-key"].FirstOrDefault();
			var apiKeyFromAppsettings = _configuration.GetSection("ApiKey").Value;
			if(apiKeyFromHeader == apiKeyFromAppsettings)
			{
				await _next(context);
			}
			else 
			{
				context.Response.StatusCode = StatusCodes.Status401Unauthorized;
				await context.Response.WriteAsync("Unauthorized");
			}
		}
	}
}
