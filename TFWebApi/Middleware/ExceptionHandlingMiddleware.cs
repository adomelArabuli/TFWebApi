namespace TFWebApi.Middleware
{
	public class ExceptionHandlingMiddleware
	{
		public readonly RequestDelegate _next;

		public ExceptionHandlingMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			try
			{
				await _next(context);
			}
			catch (Exception ex)
			{
                await Console.Out.WriteLineAsync($"Exception: {ex.Message}");
				context.Response.StatusCode = StatusCodes.Status500InternalServerError;
				await context.Response.WriteAsync($"An unexpected error occured {ex.ToString()}");
            }
		}
	}
}
