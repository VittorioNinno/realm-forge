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

			//	Servizio gestione dati API
			builder.Services.AddScoped<SpeciesDataService>();

			//	Servizio gestione stato lingua UI
			builder.Services.AddScoped<LanguageStateService>();

			await builder.Build().RunAsync();
		}
	}
}