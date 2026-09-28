using RealmForge.Domain.Enums;

namespace RealmForge.Domain.DTOs
{
	///	<summary>
	///	Localized trait response DTO.
	///	</summary>
	public record TraitResponseDto(
		Guid Id,
		string Name,
		string Description,
		int RequiredLevel,
		RulesetVersion Ruleset,
		bool IsOfficialSRD
	);

	///	<summary>
	///	Localized subspecies or lineage response DTO, including exclusive traits.
	///	</summary>
	public record SubspeciesResponseDto(
		Guid Id,
		string Name,
		string Description,
		int? BaseSpeedOverrideInFeet,
		RulesetVersion Ruleset,
		bool IsOfficialSRD,
		List<TraitResponseDto> Traits
	);

	///	<summary>
	///	Lightweight species response DTO for archive and grid listings.
	///	Default values for counts guarantee backward compatibility with existing constructors.
	///	</summary>
	public record SpeciesResponseDto(
		Guid Id,
		string Name,
		string Description,
		int BaseSpeedInFeet,
		List<CreatureSize> AllowedSizes,
		CreatureType CreatureType,
		RulesetVersion Ruleset,
		bool IsOfficialSRD,
		LanguageCode Language,
		int TraitCount = 0,
		int SubspeciesCount = 0
	);

	///	<summary>
	///	Comprehensive species response DTO containing full trees of base traits and subspecies/lineages.
	///	</summary>
	public record SpeciesDetailResponseDto(
		Guid Id,
		string Name,
		string Description,
		int BaseSpeedInFeet,
		List<CreatureSize> AllowedSizes,
		CreatureType CreatureType,
		RulesetVersion Ruleset,
		bool IsOfficialSRD,
		LanguageCode Language,
		List<TraitResponseDto> BaseTraits,
		List<SubspeciesResponseDto> Subspecies
	);

	///	<summary>
	///	Payload DTO for creating a trait along with its localized entries.
	///	</summary>
	public record CreateTraitDto(
		int RequiredLevel,
		RulesetVersion Ruleset,
		bool IsOfficialSRD,
		List<TraitTranslationDto> Translations
	);

	///	<summary>
	///	Payload DTO for creating a subspecies along with its localized entries and exclusive traits.
	///	</summary>
	public record CreateSubspeciesDto(
		int? BaseSpeedOverrideInFeet,
		RulesetVersion Ruleset,
		bool IsOfficialSRD,
		List<SubspeciesTranslationDto> Translations,
		List<CreateTraitDto>? Traits = null
	);

	///	<summary>
	///	Payload DTO for creating a new species along with its localized entries, base traits, and subspecies.
	///	</summary>
	public record CreateSpeciesDto(
		int BaseSpeedInFeet,
		List<CreatureSize> AllowedSizes,
		CreatureType CreatureType,
		RulesetVersion Ruleset,
		bool IsOfficialSRD,
		List<SpeciesTranslationDto> Translations,
		List<CreateTraitDto>? BaseTraits = null,
		List<CreateSubspeciesDto>? Subspecies = null
	);

	///	<summary>
	///	Payload DTO for updating an existing species.
	///	</summary>
	public record UpdateSpeciesDto(
		Guid Id,
		int BaseSpeedInFeet,
		List<CreatureSize> AllowedSizes,
		CreatureType CreatureType,
		RulesetVersion Ruleset,
		bool IsOfficialSRD,
		List<SpeciesTranslationDto> Translations
	);

	///	<summary>
	///	Localized translation entry for species creation and editing.
	///	</summary>
	public record SpeciesTranslationDto(
		LanguageCode Language,
		string Name,
		string Description
	);

	///	<summary>
	///	Localized translation entry for subspecies creation and seeding.
	///	</summary>
	public record SubspeciesTranslationDto(
		LanguageCode Language,
		string Name,
		string Description
	);

	///	<summary>
	///	Localized translation entry for trait creation and seeding.
	///	</summary>
	public record TraitTranslationDto(
		LanguageCode Language,
		string Name,
		string Description
	);
}