using RealmForge.Domain.Enums;

namespace RealmForge.Domain.DTOs
{
	///	<summary>
	///	Response DTO containing species details localized in the requested language.
	///	</summary>
	public record SpeciesResponseDto(
		Guid Id,
		string Name,
		string Description,
		int BaseSpeedInFeet,
		List<CreatureSize> AllowedSizes,
		CreatureType CreatureType,
		bool IsOfficialSRD,
		LanguageCode Language
	);

	///	<summary>
	///	Payload DTO for creating a new species along with its localized entries.
	///	</summary>
	public record CreateSpeciesDto(
		int BaseSpeedInFeet,
		List<CreatureSize> AllowedSizes,
		CreatureType CreatureType,
		bool IsOfficialSRD,
		List<SpeciesTranslationDto> Translations
	);

	///	<summary>
	///	DTO representing a localized name and description for a species.
	///	</summary>
	public record SpeciesTranslationDto(
		LanguageCode Language,
		string Name,
		string Description
	);
}