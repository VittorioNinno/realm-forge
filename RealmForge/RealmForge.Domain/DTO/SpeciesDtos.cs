using RealmForge.Domain.Enums;

namespace RealmForge.Domain.DTOs;

//	DTO per la restituzione di una specie (con testi nella lingua richiesta)
public record SpeciesResponseDto(
	Guid Id,
	string Name,
	string Description,
	int BaseSpeedInFeet,
	string Size,
	bool IsOfficialSRD,
	LanguageCode Language
);

//	DTO per la creazione di una specie con traduzione iniziale
public record CreateSpeciesDto(
	int BaseSpeedInFeet,
	string Size,
	bool IsOfficialSRD,
	List<SpeciesTranslationDto> Translations
);

public record SpeciesTranslationDto(
	LanguageCode Language,
	string Name,
	string Description
);