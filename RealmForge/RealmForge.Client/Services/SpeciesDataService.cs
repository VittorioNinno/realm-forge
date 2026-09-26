using System.Net.Http.Json;
using Microsoft.Extensions.Logging;
using RealmForge.Domain.DTOs;
using RealmForge.Domain.Enums;

namespace RealmForge.Client.Services
{
	public class SpeciesDataService
	{
		private readonly HttpClient _http;
		private readonly ILogger<SpeciesDataService> _logger;

		public SpeciesDataService(HttpClient http, ILogger<SpeciesDataService> logger)
		{
			_http = http;
			_logger = logger;
		}

		public async Task<List<SpeciesResponseDto>> GetSpeciesAsync(
			LanguageCode language,
			RulesetVersion? ruleset = null,
			bool? isOfficial = null)
		{
			try
			{
				var url = $"api/species?lang={(int)language}";
				if (ruleset.HasValue)
				{
					url += $"&ruleset={(int)ruleset.Value}";
				}
				if (isOfficial.HasValue)
				{
					url += $"&isOfficial={isOfficial.Value.ToString().ToLower()}";
				}

				var response = await _http.GetFromJsonAsync<List<SpeciesResponseDto>>(url);
				return response ?? new List<SpeciesResponseDto>();
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Failed to load species from API for language {Language}", language);
				return new List<SpeciesResponseDto>();
			}
		}

		public async Task<SpeciesDetailResponseDto?> GetSpeciesDetailAsync(Guid id, LanguageCode language)
		{
			try
			{
				var url = $"api/species/{id}?lang={(int)language}";
				return await _http.GetFromJsonAsync<SpeciesDetailResponseDto>(url);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Failed to load species detail from API for ID {SpeciesId} and language {Language}", id, language);
				return null;
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
				_logger.LogError(ex, "Error creating species");
				return false;
			}
		}
	}
}