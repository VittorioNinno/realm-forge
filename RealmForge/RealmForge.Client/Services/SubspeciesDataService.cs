using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using RealmForge.Domain.DTOs;
using RealmForge.Domain.Enums;

namespace RealmForge.Client.Services
{
	///	<summary>
	///	Client service handling HTTP communication for subspecies data.
	///	</summary>
	public class SubspeciesDataService
	{
		private readonly HttpClient _http;
		private readonly ILogger<SubspeciesDataService> _logger;

		///	<summary>
		///	Initializes a new instance of the SubspeciesDataService.
		///	</summary>
		public SubspeciesDataService(HttpClient http, ILogger<SubspeciesDataService> logger)
		{
			_http = http;
			_logger = logger;
		}

		///	<summary>
		///	Retrieves all subspecies filtered by language, ruleset, and official status.
		///	</summary>
		public async Task<List<SubspeciesResponseDto>> GetAllAsync(
			LanguageCode lang,
			RulesetVersion? ruleset = null,
			bool? isOfficial = null)
		{
			try
			{
				var url = $"api/subspecies?lang={(int)lang}";

				if (ruleset.HasValue)
				{
					url += $"&ruleset={(int)ruleset.Value}";
				}

				if (isOfficial.HasValue)
				{
					url += $"&isOfficial={isOfficial.Value.ToString().ToLower()}";
				}

				var response = await _http.GetFromJsonAsync<List<SubspeciesResponseDto>>(url);
				return response ?? new List<SubspeciesResponseDto>();
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Failed to load subspecies from API for language {Language}", lang);
				return new List<SubspeciesResponseDto>();
			}
		}

		///	<summary>
		///	Retrieves a specific subspecies by its identifier.
		///	</summary>
		public async Task<SubspeciesResponseDto?> GetByIdAsync(Guid id, LanguageCode lang)
		{
			try
			{
				var url = $"api/subspecies/{id}?lang={(int)lang}";
				return await _http.GetFromJsonAsync<SubspeciesResponseDto>(url);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Failed to load subspecies detail from API for ID {SubspeciesId} and language {Language}", id, lang);
				return null;
			}
		}

		///	<summary>
		///	Creates a new subspecies linked to a specific parent species.
		///	</summary>
		public async Task<SubspeciesResponseDto?> CreateAsync(Guid speciesId, CreateSubspeciesDto dto)
		{
			try
			{
				var response = await _http.PostAsJsonAsync($"api/species/{speciesId}/subspecies", dto);

				if (response.IsSuccessStatusCode)
				{
					return await response.Content.ReadFromJsonAsync<SubspeciesResponseDto>();
				}

				_logger.LogWarning("API returned {StatusCode} when creating subspecies for parent {SpeciesId}", response.StatusCode, speciesId);
				return null;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error creating subspecies for parent {SpeciesId}", speciesId);
				return null;
			}
		}

		///	<summary>
		///	Updates an existing subspecies.
		///	</summary>
		public async Task<bool> UpdateAsync(Guid id, UpdateSubspeciesDto dto)
		{
			try
			{
				var response = await _http.PutAsJsonAsync($"api/subspecies/{id}", dto);
				return response.IsSuccessStatusCode;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Failed to update subspecies with ID {SubspeciesId}", id);
				return false;
			}
		}

		///	<summary>
		///	Deletes a subspecies by its identifier.
		///	</summary>
		public async Task<bool> DeleteAsync(Guid id)
		{
			try
			{
				var response = await _http.DeleteAsync($"api/subspecies/{id}");
				return response.IsSuccessStatusCode;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Failed to delete subspecies with ID {SubspeciesId}", id);
				return false;
			}
		}
	}
}