using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Ninject;
using TFWebApi.Data;
using TFWebApi.Data.Model.DTO;
using TFWebApi.Interfaces;
using TFWebApi.Middleware;
using TFWebApi.Services;

namespace TFWebApi
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddAutoMapper(typeof(Program).Assembly);



			builder.Services.AddControllers().AddFluentValidation(cfg =>
			cfg.RegisterValidatorsFromAssemblyContaining<LectorCreateValidator>()).AddNewtonsoftJson
			(
				options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
				);

			builder.Services.AddControllers();

			builder.Services.AddDbContext<ApplicationDbContext>(options =>
			options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

			builder.Services.AddScoped<ILectorService, LectorService>();

			//var kernel = new StandardKernel(new DependencyModule(builder.Configuration));
			//builder.Services.AddSingleton<IKernel>(kernel);

			//builder.Services.AddScoped(provider => kernel.Get<ILectorService>());
			//builder.Services.AddScoped(provider => kernel.Get<IDatabaseService>());

			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthentication();

			app.UseAuthorization();

			app.UseMiddleware<RequestLoggingMiddleware>();

			app.UseMiddleware<ExceptionHandlingMiddleware>();

			app.UseMiddleware<CustomAuthenticationMiddleware>();

			app.UseMiddleware<RequestRateLimitingMiddleware>();

			app.MapControllers();

			app.Run();
		}
	}
}