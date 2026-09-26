using Scalar.AspNetCore;
using Microsoft.EntityFrameworkCore;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Api;

public class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		//	Configurazione della stringa di connessione e registrazione DbContext (PostgreSQL)
		var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
		builder.Services.AddDbContext<RealmForgeDbContext>(options =>
			options.UseNpgsql(connectionString));

		//	Registrazione dei controller
		builder.Services.AddControllers();

		//	Configurazione OpenAPI / Swagger
		builder.Services.AddOpenApi();

		const string CorsPolicyName = "AllowBlazorClient";

		builder.Services.AddCors(options =>
		{
			options.AddPolicy(CorsPolicyName, policy =>
			{
				policy.AllowAnyOrigin()
					  .AllowAnyMethod()
					  .AllowAnyHeader();
			});
		});

		var app = builder.Build();

		//	Configurazione della pipeline HTTP
		if (app.Environment.IsDevelopment())
		{
			app.MapOpenApi();
			app.MapScalarApiReference();
		}

		app.UseHttpsRedirection();

		app.UseCors(CorsPolicyName);

		app.UseAuthorization();

		app.MapControllers();

		app.Run();
	}
}