using Microsoft.EntityFrameworkCore;
using RealmForge.Infrastructure.Persistence;
using Scalar.AspNetCore;

namespace RealmForge.Api
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			//	Configure connection string and register DbContext (PostgreSQL)
			var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
			builder.Services.AddDbContext<RealmForgeDbContext>(options =>
				options.UseNpgsql(connectionString));

			//	Register controllers
			builder.Services.AddControllers();

			//	Configure OpenAPI / Swagger
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

			//	Configure the HTTP request pipeline
			if (app.Environment.IsDevelopment())
			{
				app.MapOpenApi();
				app.MapScalarApiReference();
			}

			app.UseHttpsRedirection();

			app.UseCors(CorsPolicyName);

			app.UseAuthorization();

			app.MapControllers();

			//	Execute automated database seeding during startup
			using (var scope = app.Services.CreateScope())
			{
				var services = scope.ServiceProvider;
				try
				{
					var dbContext = services.GetRequiredService<RealmForgeDbContext>();
					await RealmForge.Infrastructure.Persistence.Seeding.SpeciesSeeder.SeedAsync(dbContext);
				}
				catch (Exception ex)
				{
					var logger = services.GetRequiredService<ILogger<Program>>();
					logger.LogError(ex, "An error occurred while seeding the database.");
				}
			}

			await app.RunAsync();
		}
	}
}