using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.DTOs;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Api.Controllers
{
	///	<summary>
	///	API Controller managing subspecies operations and data retrieval.
	///	</summary>
	[ApiController]
	[Route("api/[controller]")]
	public class SubspeciesController : ControllerBase
	{
		private readonly RealmForgeDbContext _context;

		///	<summary>
		///	Initializes a new instance of the SubspeciesController.
		///	</summary>
		public SubspeciesController(RealmForgeDbContext context)
		{
			_context = context;
		}

		///	<summary>
		///	Retrieves a filtered list of all subspecies.
		///	</summary>
		[HttpGet]
		public async Task<ActionResult<IEnumerable<SubspeciesResponseDto>>> GetAll(
			[FromQuery] LanguageCode lang = LanguageCode.En,
			[FromQuery] RulesetVersion? ruleset = null,
			[FromQuery] bool? isOfficial = null)
		{
			var query = _context.Subspecies
				.Include(s => s.Translations)
				.Include(s => s.Traits)
					.ThenInclude(t => t.Translations)
				.AsSplitQuery()
				.AsNoTracking()
				.AsQueryable();

			if (ruleset.HasValue)
			{
				query = query.Where(s => s.Ruleset == ruleset.Value);
			}

			if (isOfficial.HasValue)
			{
				query = query.Where(s => s.IsOfficialSRD == isOfficial.Value);
			}

			var subspeciesList = await query.ToListAsync();

			var result = subspeciesList.Select(sub =>
			{
				var translation = sub.Translations.FirstOrDefault(t => t.Language == lang)
								  ?? sub.Translations.FirstOrDefault();

				var exclusiveTraits = sub.Traits
					.OrderBy(t => t.RequiredLevel)
					.Select(t =>
					{
						var traitTranslation = t.Translations.FirstOrDefault(tr => tr.Language == lang)
											   ?? t.Translations.FirstOrDefault();

						return new TraitResponseDto(
							t.Id,
							traitTranslation?.Name ?? "Unnamed Trait",
							traitTranslation?.Description ?? string.Empty,
							t.RequiredLevel,
							t.Ruleset,
							t.IsOfficialSRD
						);
					})
					.ToList();

				return new SubspeciesResponseDto(
					sub.Id,
					translation?.Name ?? "Unnamed Subspecies",
					translation?.Description ?? string.Empty,
					sub.BaseSpeedOverrideInFeet,
					sub.Ruleset,
					sub.IsOfficialSRD,
					exclusiveTraits
				);
			});

			return Ok(result);
		}

		///	<summary>
		///	Retrieves a specific subspecies by its unique identifier.
		///	</summary>
		[HttpGet("{id:guid}")]
		public async Task<ActionResult<SubspeciesResponseDto>> GetById(
			Guid id,
			[FromQuery] LanguageCode lang = LanguageCode.En)
		{
			var sub = await _context.Subspecies
				.Include(s => s.Translations)
				.Include(s => s.Traits)
					.ThenInclude(t => t.Translations)
				.AsSplitQuery()
				.AsNoTracking()
				.FirstOrDefaultAsync(s => s.Id == id);

			if (sub == null)
			{
				return NotFound();
			}

			var translation = sub.Translations.FirstOrDefault(t => t.Language == lang)
							  ?? sub.Translations.FirstOrDefault();

			var exclusiveTraits = sub.Traits
				.OrderBy(t => t.RequiredLevel)
				.Select(t =>
				{
					var traitTranslation = t.Translations.FirstOrDefault(tr => tr.Language == lang)
										   ?? t.Translations.FirstOrDefault();

					return new TraitResponseDto(
						t.Id,
						traitTranslation?.Name ?? "Unnamed Trait",
						traitTranslation?.Description ?? string.Empty,
						t.RequiredLevel,
						t.Ruleset,
						t.IsOfficialSRD
					);
				})
				.ToList();

			var response = new SubspeciesResponseDto(
				sub.Id,
				translation?.Name ?? "Unnamed Subspecies",
				translation?.Description ?? string.Empty,
				sub.BaseSpeedOverrideInFeet,
				sub.Ruleset,
				sub.IsOfficialSRD,
				exclusiveTraits
			);

			return Ok(response);
		}

		///	<summary>
		///	Creates a new subspecies linked to a specific parent species.
		///	</summary>
		[HttpPost("~/api/species/{speciesId:guid}/subspecies")]
		public async Task<ActionResult<SubspeciesResponseDto>> Create(Guid speciesId, [FromBody] CreateSubspeciesDto dto)
		{
			if (dto.Translations == null || !dto.Translations.Any())
			{
				return BadRequest("At least one translation must be provided.");
			}

			var speciesExists = await _context.Species.AnyAsync(s => s.Id == speciesId);
			if (!speciesExists)
			{
				return NotFound("Parent species not found.");
			}

			var subspecies = new Subspecies
			{
				SpeciesId = speciesId,
				BaseSpeedOverrideInFeet = dto.BaseSpeedOverrideInFeet,
				Ruleset = dto.Ruleset,
				IsOfficialSRD = dto.IsOfficialSRD,
				Translations = dto.Translations.Select(t => new SubspeciesTranslation
				{
					Language = t.Language,
					Name = t.Name,
					Description = t.Description
				}).ToList(),
				Traits = dto.Traits?.Select(tr => new Trait
				{
					RequiredLevel = tr.RequiredLevel,
					Ruleset = tr.Ruleset,
					IsOfficialSRD = tr.IsOfficialSRD,
					Translations = tr.Translations.Select(trt => new TraitTranslation
					{
						Language = trt.Language,
						Name = trt.Name,
						Description = trt.Description
					}).ToList()
				}).ToList() ?? new List<Trait>()
			};

			_context.Subspecies.Add(subspecies);
			await _context.SaveChangesAsync();

			var firstTranslation = subspecies.Translations.FirstOrDefault();

			var response = new SubspeciesResponseDto(
				subspecies.Id,
				firstTranslation?.Name ?? "Unnamed Subspecies",
				firstTranslation?.Description ?? string.Empty,
				subspecies.BaseSpeedOverrideInFeet,
				subspecies.Ruleset,
				subspecies.IsOfficialSRD,
				new List<TraitResponseDto>()
			);

			return CreatedAtAction(nameof(GetById), new { id = subspecies.Id }, response);
		}

		///	<summary>
		///	Updates an existing subspecies mechanical data and translations.
		///	</summary>
		[HttpPut("{id:guid}")]
		public async Task<IActionResult> UpdateSubspecies(Guid id, [FromBody] UpdateSubspeciesDto dto)
		{
			if (id != dto.Id)
			{
				return BadRequest("ID mismatch between route and payload.");
			}

			var subspecies = await _context.Subspecies
				.Include(s => s.Translations)
				.FirstOrDefaultAsync(s => s.Id == id);

			if (subspecies == null)
			{
				return NotFound();
			}

			subspecies.BaseSpeedOverrideInFeet = dto.BaseSpeedOverrideInFeet;
			subspecies.Ruleset = dto.Ruleset;
			subspecies.IsOfficialSRD = dto.IsOfficialSRD;

			foreach (var tDto in dto.Translations)
			{
				var existingTranslation = subspecies.Translations.FirstOrDefault(t => t.Language == tDto.Language);

				if (existingTranslation != null)
				{
					existingTranslation.Name = tDto.Name;
					existingTranslation.Description = tDto.Description;
				}
				else
				{
					subspecies.Translations.Add(new SubspeciesTranslation
					{
						Language = tDto.Language,
						Name = tDto.Name,
						Description = tDto.Description
					});
				}
			}

			var dtoLanguages = dto.Translations.Select(t => t.Language).ToList();
			var translationsToRemove = subspecies.Translations
				.Where(t => !dtoLanguages.Contains(t.Language))
				.ToList();

			if (translationsToRemove.Any())
			{
				_context.SubspeciesTranslations.RemoveRange(translationsToRemove);
			}

			await _context.SaveChangesAsync();

			return NoContent();
		}

		///	<summary>
		///	Deletes a subspecies by its unique identifier.
		///	</summary>
		[HttpDelete("{id:guid}")]
		public async Task<IActionResult> DeleteSubspecies(Guid id)
		{
			var subspecies = await _context.Subspecies.FindAsync(id);

			if (subspecies == null)
			{
				return NotFound();
			}

			_context.Subspecies.Remove(subspecies);
			await _context.SaveChangesAsync();

			return NoContent();
		}
	}
}