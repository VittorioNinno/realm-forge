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
					tr?.Name ?? "Sconosciuto",
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
				tr?.Name ?? "Sconosciuto",
				feat.Category,
				feat.Prerequisite,
				feat.Ruleset,
				feat.IsOfficialSRD,
				tr?.Description ?? string.Empty
			));
		}

		[HttpPost]
		public async Task<IActionResult> CreateFeat([FromBody] CreateFeatDto dto)
		{
			var feat = new Feat
			{
				Id = Guid.NewGuid(),
				Category = dto.Category,
				Prerequisite = dto.Prerequisite,
				Ruleset = dto.Ruleset,
				IsOfficialSRD = dto.IsOfficialSRD,
				Translations = dto.Translations.Select(t => new FeatTranslation
				{
					Id = Guid.NewGuid(),
					Language = t.Language,
					Name = t.Name,
					Description = t.Description
				}).ToList()
			};

			_context.Feats.Add(feat);
			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(GetFeatDetail), new { id = feat.Id }, feat.Id);
		}
	}
}