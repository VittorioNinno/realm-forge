using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.DTOs;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class SpeciesController : ControllerBase
	{
		private readonly RealmForgeDbContext _context;

		public SpeciesController(RealmForgeDbContext context)
		{
			_context = context;
		}

		//	GET: api/species?lang=1&ruleset=2&isOfficial=true
		[HttpGet]
		public async Task<ActionResult<IEnumerable<SpeciesResponseDto>>> GetAll(
			[FromQuery] LanguageCode lang = LanguageCode.En,
			[FromQuery] RulesetVersion? ruleset = null,
			[FromQuery] bool? isOfficial = null)
		{
			var query = _context.Species
				.Include(s => s.Translations)
				.Include(s => s.Traits)
				.Include(s => s.Subspecies)
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

			var speciesList = await query.ToListAsync();

			var result = speciesList.Select(s =>
			{
				//	Find requested translation or fall back to the first available
				var translation = s.Translations.FirstOrDefault(t => t.Language == lang)
								  ?? s.Translations.FirstOrDefault();

				return new SpeciesResponseDto(
					s.Id,
					translation?.Name ?? "Unnamed",
					translation?.Description ?? string.Empty,
					s.BaseSpeedInFeet,
					s.AllowedSizes,
					s.CreatureType,
					s.Ruleset,
					s.IsOfficialSRD,
					translation?.Language ?? lang,
					s.Traits.Count,
					s.Subspecies.Count
				);
			});

			return Ok(result);
		}

		//	GET: api/species/{id}?lang=1
		[HttpGet("{id:guid}")]
		public async Task<ActionResult<SpeciesDetailResponseDto>> GetById(
			Guid id,
			[FromQuery] LanguageCode lang = LanguageCode.En)
		{
			var species = await _context.Species
				.Include(s => s.Translations)
				.Include(s => s.Traits)
					.ThenInclude(t => t.Translations)
				.Include(s => s.Subspecies)
					.ThenInclude(sub => sub.Translations)
				.Include(s => s.Subspecies)
					.ThenInclude(sub => sub.Traits)
						.ThenInclude(t => t.Translations)
				.AsNoTracking()
				.FirstOrDefaultAsync(s => s.Id == id);

			if (species == null)
			{
				return NotFound();
			}

			var translation = species.Translations.FirstOrDefault(t => t.Language == lang)
							  ?? species.Translations.FirstOrDefault();

			//	Localize species base traits
			var baseTraits = species.Traits
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

			//	Localize subspecies and their respective exclusive traits
			var subspeciesList = species.Subspecies.Select(sub =>
			{
				var subTranslation = sub.Translations.FirstOrDefault(tr => tr.Language == lang)
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
					subTranslation?.Name ?? "Unnamed Subspecies",
					subTranslation?.Description ?? string.Empty,
					sub.BaseSpeedOverrideInFeet,
					sub.Ruleset,
					sub.IsOfficialSRD,
					exclusiveTraits
				);
			})
			.ToList();

			var response = new SpeciesDetailResponseDto(
				species.Id,
				translation?.Name ?? "Unnamed",
				translation?.Description ?? string.Empty,
				species.BaseSpeedInFeet,
				species.AllowedSizes,
				species.CreatureType,
				species.Ruleset,
				species.IsOfficialSRD,
				translation?.Language ?? lang,
				baseTraits,
				subspeciesList
			);

			return Ok(response);
		}

		//	POST: api/species
		[HttpPost]
		public async Task<ActionResult<SpeciesResponseDto>> Create([FromBody] CreateSpeciesDto dto)
		{
			if (dto.Translations == null || !dto.Translations.Any())
			{
				return BadRequest("At least one translation must be provided.");
			}

			if (dto.AllowedSizes == null || !dto.AllowedSizes.Any())
			{
				return BadRequest("At least one size must be selected.");
			}

			var species = new Species
			{
				BaseSpeedInFeet = dto.BaseSpeedInFeet,
				AllowedSizes = dto.AllowedSizes,
				CreatureType = dto.CreatureType,
				Ruleset = dto.Ruleset,
				IsOfficialSRD = dto.IsOfficialSRD,
				Translations = dto.Translations.Select(t => new SpeciesTranslation
				{
					Language = t.Language,
					Name = t.Name,
					Description = t.Description
				}).ToList(),
				Traits = dto.BaseTraits?.Select(tr => new Trait
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
				}).ToList() ?? new List<Trait>(),
				Subspecies = dto.Subspecies?.Select(sub => new Subspecies
				{
					BaseSpeedOverrideInFeet = sub.BaseSpeedOverrideInFeet,
					Ruleset = sub.Ruleset,
					IsOfficialSRD = sub.IsOfficialSRD,
					Translations = sub.Translations.Select(sbt => new SubspeciesTranslation
					{
						Language = sbt.Language,
						Name = sbt.Name,
						Description = sbt.Description
					}).ToList(),
					Traits = sub.Traits?.Select(tr => new Trait
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
				}).ToList() ?? new List<Subspecies>()
			};

			_context.Species.Add(species);
			await _context.SaveChangesAsync();

			var firstTranslation = species.Translations.FirstOrDefault();

			var response = new SpeciesResponseDto(
				species.Id,
				firstTranslation?.Name ?? "Unnamed",
				firstTranslation?.Description ?? string.Empty,
				species.BaseSpeedInFeet,
				species.AllowedSizes,
				species.CreatureType,
				species.Ruleset,
				species.IsOfficialSRD,
				firstTranslation?.Language ?? LanguageCode.En,
				TraitCount: species.Traits.Count,
				SubspeciesCount: species.Subspecies.Count
			);

			return CreatedAtAction(nameof(GetById), new { id = species.Id }, response);
		}
	}
}