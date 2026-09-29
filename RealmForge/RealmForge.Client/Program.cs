using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RealmForge.Client;
using RealmForge.Client.Services;

namespace RealmForge.Client
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebAssemblyHostBuilder.CreateDefault(args);

			builder.RootComponents.Add<App>("#app");
			builder.RootComponents.Add<HeadOutlet>("head::after");

			builder.Services.AddScoped(sp => new HttpClient
			{
				BaseAddress = new Uri("https://localhost:7086/")
			});

			//	API data management service
			builder.Services.AddScoped<SpeciesDataService>();
			builder.Services.AddScoped<SubspeciesDataService>();
			builder.Services.AddScoped<FeatDataService>();

			//	UI language state management service
			builder.Services.AddScoped<LanguageStateService>();

			await builder.Build().RunAsync();
		}
	}
}