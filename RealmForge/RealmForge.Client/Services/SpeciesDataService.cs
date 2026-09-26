using System.Net.Http.Json;
using RealmForge.Domain.DTOs;
using RealmForge.Domain.Enums;

namespace RealmForge.Client.Services
{
	public class SpeciesDataService
	{
		private readonly HttpClient _http;

		public SpeciesDataService(HttpClient http)
		{
			_http = http;
		}

		public async Task<List<SpeciesResponseDto>> GetSpeciesAsync(LanguageCode lang)
		{
			try
			{
				var response = await _http.GetFromJsonAsync<List<SpeciesResponseDto>>($"api/species?lang={(int)lang}");
				return response ?? new List<SpeciesResponseDto>();
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error retrieving species: {ex.Message}");
				return new List<SpeciesResponseDto>();
			}
		}

		public async Task<bool> CreateSpeciesAsync(CreateSpeciesDto dto)
		{
			try
			{
				var response = await _http.PostAsJsonAsync("api/species", dto);
				return response.IsSuccessStatusCode;
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error creating species: {ex.Message}");
				return false;
			}
		}
	}
}