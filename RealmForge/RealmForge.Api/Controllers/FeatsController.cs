using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.DTOs;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Server.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class FeatsController : ControllerBase
	{
		private readonly RealmForgeDbContext _context;

		public FeatsController(RealmForgeDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<ActionResult<List<FeatResponseDto>>> GetFeats(
			[FromQuery] int lang = (int)LanguageCode.It,
			[FromQuery] int? category = null,
			[FromQuery] int? ruleset = null,
			[FromQuery] bool? isOfficial = null)
		{
			var targetLang = (LanguageCode)lang;
			var query = _context.Feats
				.Include(f => f.Translations)
				.AsSplitQuery()
				.AsNoTracking();

			if (category.HasValue)
			{
				query = query.Where(f => f.Category == (FeatCategory)category.Value);
			}

			if (ruleset.HasValue)
			{
				query = query.Where(f => f.Ruleset == (RulesetVersion)ruleset.Value);
			}

			if (isOfficial.HasValue)
			{
				query = query.Where(f => f.IsOfficialSRD == isOfficial.Value);
			}

			var feats = await query.ToListAsync();

			var dtos = feats.Select(f =>
			{
				var tr = f.Translations.FirstOrDefault(t => t.Language == targetLang)
						 ?? f.Translations.FirstOrDefault(t => t.Language == LanguageCode.It)
						 ?? f.Translations.FirstOrDefault();

				var desc = tr?.Description ?? string.Empty;
				var shortDesc = desc.Length > 160 ? desc[..157] + "..." : desc;

				return new FeatResponseDto(
					f.Id,
					tr?.Name ?? "Unknown",
					f.Category,
					f.Prerequisite,
					f.Ruleset,
					f.IsOfficialSRD,
					shortDesc
				);
			}).OrderBy(f => f.Name).ToList();

			return Ok(dtos);
		}

		[HttpGet("{id:guid}")]
		public async Task<ActionResult<FeatDetailResponseDto>> GetFeatDetail(Guid id, [FromQuery] int lang = (int)LanguageCode.It)
		{
			var targetLang = (LanguageCode)lang;
			var feat = await _context.Feats
				.Include(f => f.Translations)
				.AsSplitQuery()
				.AsNoTracking()
				.FirstOrDefaultAsync(f => f.Id == id);

			if (feat == null)
			{
				return NotFound();
			}

			var tr = feat.Translations.FirstOrDefault(t => t.Language == targetLang)
					 ?? feat.Translations.FirstOrDefault(t => t.Language == LanguageCode.It)
					 ?? feat.Translations.FirstOrDefault();

			return Ok(new FeatDetailResponseDto(
				feat.Id,
				tr?.Name ?? "Unknown",
				feat.Category,
				feat.Prerequisite,
				feat.Ruleset,
				feat.IsOfficialSRD,
				tr?.Description ?? string.Empty
			));
		}

		[HttpPost]
		public async Task<ActionResult<FeatResponseDto>> CreateFeat([FromBody] CreateFeatDto dto)
		{
			if (dto.Translations == null || !dto.Translations.Any())
			{
				return BadRequest("At least one translation must be provided.");
			}

			//	Map payload to entity, allowing Entity Framework to handle identity generation
			var feat = new Feat
			{
				Category = dto.Category,
				Prerequisite = dto.Prerequisite,
				Ruleset = dto.Ruleset,
				IsOfficialSRD = dto.IsOfficialSRD,
				Translations = dto.Translations.Select(t => new FeatTranslation
				{
					Language = t.Language,
					Name = t.Name,
					Description = t.Description
				}).ToList()
			};

			_context.Feats.Add(feat);
			await _context.SaveChangesAsync();

			var firstTranslation = feat.Translations.FirstOrDefault();
			var response = new FeatResponseDto(
				feat.Id,
				firstTranslation?.Name ?? "Unknown",
				feat.Category,
				feat.Prerequisite,
				feat.Ruleset,
				feat.IsOfficialSRD,
				firstTranslation?.Description ?? string.Empty
			);

			return CreatedAtAction(nameof(GetFeatDetail), new { id = feat.Id }, response);
		}

		[HttpPut("{id:guid}")]
		public async Task<IActionResult> UpdateFeat(Guid id, [FromBody] UpdateFeatDto dto)
		{
			if (id != dto.Id)
			{
				return BadRequest("ID mismatch between route and payload.");
			}

			var feat = await _context.Feats
				.Include(f => f.Translations)
				.FirstOrDefaultAsync(f => f.Id == id);

			if (feat == null)
			{
				return NotFound();
			}

			// Update core mechanical data
			feat.Category = dto.Category;
			feat.Prerequisite = dto.Prerequisite;
			feat.Ruleset = dto.Ruleset;
			feat.IsOfficialSRD = dto.IsOfficialSRD;

			var dtoLanguages = dto.Translations.Select(t => t.Language).ToList();

			//	Safely remove translations omitted from the payload to prevent orphan records
			var translationsToRemove = feat.Translations
				.Where(t => !dtoLanguages.Contains(t.Language))
				.ToList();

			foreach (var tr in translationsToRemove)
			{
				feat.Translations.Remove(tr);
			}

			//	Process incoming translations for updates or insertions
			foreach (var tDto in dto.Translations)
			{
				var existingTranslation = feat.Translations.FirstOrDefault(t => t.Language == tDto.Language);

				if (existingTranslation != null)
				{
					existingTranslation.Name = tDto.Name;
					existingTranslation.Description = tDto.Description;
				}
				else
				{
					feat.Translations.Add(new FeatTranslation
					{
						Language = tDto.Language,
						Name = tDto.Name,
						Description = tDto.Description
					});
				}
			}

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException ex)
			{
				//	Advanced diagnostics for tracking entity failure states
				var failedEntityName = ex.Entries.FirstOrDefault()?.Entity.GetType().Name ?? "Unknown";
				var state = ex.Entries.FirstOrDefault()?.State.ToString() ?? "N/A";

				throw new Exception($"Concurrency error on entity '{failedEntityName}' during '{state}' operation. Verify that the database primary keys match the payload and that no orphaned data is interfering.", ex);
			}

			return NoContent();
		}

		[HttpDelete("{id:guid}")]
		public async Task<IActionResult> DeleteFeat(Guid id)
		{
			var feat = await _context.Feats.FindAsync(id);

			if (feat == null)
			{
				return NotFound();
			}

			_context.Feats.Remove(feat);
			await _context.SaveChangesAsync();

			return NoContent();
		}
	}
}