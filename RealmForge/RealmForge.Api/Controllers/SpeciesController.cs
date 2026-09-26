using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.DTOs;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SpeciesController : ControllerBase
{
	private readonly RealmForgeDbContext _context;

	public SpeciesController(RealmForgeDbContext context)
	{
		_context = context;
	}

	//	GET: api/species?lang=1 (1 = En, 2 = It)
	[HttpGet]
	public async Task<ActionResult<IEnumerable<SpeciesResponseDto>>> GetAll([FromQuery] LanguageCode lang = LanguageCode.En)
	{
		var speciesList = await _context.Species
			.Include(s => s.Translations)
			.AsNoTracking()
			.ToListAsync();

		var result = speciesList.Select(s =>
		{
			//	Cerca la traduzione richiesta, altrimenti fallback sulla prima disponibile
			var translation = s.Translations.FirstOrDefault(t => t.Language == lang)
							  ?? s.Translations.FirstOrDefault();

			return new SpeciesResponseDto(
				s.Id,
				translation?.Name ?? "Unnamed",
				translation?.Description ?? string.Empty,
				s.BaseSpeedInFeet,
				s.Size,
				s.IsOfficialSRD,
				translation?.Language ?? lang
			);
		});

		return Ok(result);
	}

	//	GET: api/species/{id}?lang=1
	[HttpGet("{id:guid}")]
	public async Task<ActionResult<SpeciesResponseDto>> GetById(Guid id, [FromQuery] LanguageCode lang = LanguageCode.En)
	{
		var species = await _context.Species
			.Include(s => s.Translations)
			.AsNoTracking()
			.FirstOrDefaultAsync(s => s.Id == id);

		if (species == null)
			return NotFound();

		var translation = species.Translations.FirstOrDefault(t => t.Language == lang)
						  ?? species.Translations.FirstOrDefault();

		var response = new SpeciesResponseDto(
			species.Id,
			translation?.Name ?? "Unnamed",
			translation?.Description ?? string.Empty,
			species.BaseSpeedInFeet,
			species.Size,
			species.IsOfficialSRD,
			translation?.Language ?? lang
		);

		return Ok(response);
	}

	//	POST: api/species
	[HttpPost]
	public async Task<ActionResult<SpeciesResponseDto>> Create([FromBody] CreateSpeciesDto dto)
	{
		var species = new Species
		{
			BaseSpeedInFeet = dto.BaseSpeedInFeet,
			Size = dto.Size,
			IsOfficialSRD = dto.IsOfficialSRD,
			Translations = dto.Translations.Select(t => new SpeciesTranslation
			{
				Language = t.Language,
				Name = t.Name,
				Description = t.Description
			}).ToList()
		};

		_context.Species.Add(species);
		await _context.SaveChangesAsync();

		var firstTranslation = species.Translations.FirstOrDefault();

		var response = new SpeciesResponseDto(
			species.Id,
			firstTranslation?.Name ?? "Unnamed",
			firstTranslation?.Description ?? string.Empty,
			species.BaseSpeedInFeet,
			species.Size,
			species.IsOfficialSRD,
			firstTranslation?.Language ?? LanguageCode.En
		);

		return CreatedAtAction(nameof(GetById), new { id = species.Id }, response);
	}
}