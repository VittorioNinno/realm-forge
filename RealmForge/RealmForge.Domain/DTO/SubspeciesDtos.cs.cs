using System;
using System.Collections.Generic;
using RealmForge.Domain.Enums;

namespace RealmForge.Domain.DTOs
{
	/// <summary>
	/// Localized subspecies or lineage response DTO, including exclusive traits.
	/// </summary>
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
	///	Payload DTO for updating an existing subspecies.
	///	</summary>
	public record UpdateSubspeciesDto(
		Guid Id,
		int? BaseSpeedOverrideInFeet,
		RulesetVersion Ruleset,
		bool IsOfficialSRD,
		List<SubspeciesTranslationDto> Translations
	);

	///	<summary>
	///	Localized translation entry for subspecies creation and seeding.
	///	</summary>
	public record SubspeciesTranslationDto(
		LanguageCode Language,
		string Name,
		string Description
	);
}