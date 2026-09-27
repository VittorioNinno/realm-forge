using RealmForge.Domain.Enums;

namespace RealmForge.Domain.DTOs
{
	public record FeatResponseDto(
		Guid Id,
		string Name,
		FeatCategory Category,
		string? Prerequisite,
		RulesetVersion Ruleset,
		bool IsOfficialSRD,
		string ShortDescription
	);

	public record FeatDetailResponseDto(
		Guid Id,
		string Name,
		FeatCategory Category,
		string? Prerequisite,
		RulesetVersion Ruleset,
		bool IsOfficialSRD,
		string Description
	);

	public class CreateFeatDto
	{
		public FeatCategory Category { get; set; }
		public string? Prerequisite { get; set; }
		public RulesetVersion Ruleset { get; set; }
		public bool IsOfficialSRD { get; set; }
		public List<CreateFeatTranslationDto> Translations { get; set; } = new();
	}

	public class CreateFeatTranslationDto
	{
		public LanguageCode Language { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
	}
}