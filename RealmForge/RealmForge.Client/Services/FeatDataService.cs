using System.Net.Http.Json;
using Microsoft.Extensions.Logging;
using RealmForge.Domain.DTOs;
using RealmForge.Domain.Enums;

namespace RealmForge.Client.Services
{
	public class FeatDataService
	{
		private readonly HttpClient _http;
		private readonly ILogger<FeatDataService> _logger;

		public FeatDataService(HttpClient http, ILogger<FeatDataService> logger)
		{
			_http = http;
			_logger = logger;
		}

		public async Task<List<FeatResponseDto>> GetFeatsAsync(
			LanguageCode language,
			FeatCategory? category = null,
			RulesetVersion? ruleset = null,
			bool? isOfficial = null)
		{
			try
			{
				var url = $"api/feats?lang={(int)language}";
				if (category.HasValue)
				{
					url += $"&category={(int)category.Value}";
				}
				if (ruleset.HasValue)
				{
					url += $"&ruleset={(int)ruleset.Value}";
				}
				if (isOfficial.HasValue)
				{
					url += $"&isOfficial={isOfficial.Value.ToString().ToLower()}";
				}

				var response = await _http.GetFromJsonAsync<List<FeatResponseDto>>(url);
				return response ?? new List<FeatResponseDto>();
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Failed to load feats from API for language {Language}", language);
				return new List<FeatResponseDto>();
			}
		}

		public async Task<FeatDetailResponseDto?> GetFeatDetailAsync(Guid id, LanguageCode language)
		{
			try
			{
				var url = $"api/feats/{id}?lang={(int)language}";
				return await _http.GetFromJsonAsync<FeatDetailResponseDto>(url);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Failed to load feat detail from API for ID {FeatId} and language {Language}", id, language);
				return null;
			}
		}

		public async Task<bool> CreateFeatAsync(CreateFeatDto dto)
		{
			try
			{
				var response = await _http.PostAsJsonAsync("api/feats", dto);
				return response.IsSuccessStatusCode;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error creating feat");
				return false;
			}
		}
	}
}