using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
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

			//	Configurazione dell'HttpClient puntato all'indirizzo dell'API
			builder.Services.AddScoped(sp => new HttpClient
			{
				BaseAddress = new Uri("https://localhost:7086/")
			});

			//	Registrazione del servizio per il recupero delle specie
			builder.Services.AddScoped<SpeciesDataService>();

			await builder.Build().RunAsync();
		}
	}
}