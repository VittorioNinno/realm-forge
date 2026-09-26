using RealmForge.Domain.Enums;

namespace RealmForge.Domain.Common
{
	public abstract class GameEntity
	{
		public Guid Id { get; set; } = Guid.NewGuid();

		//	Applicable ruleset version (defaulting to the modern 2024 revision)
		public RulesetVersion Ruleset { get; set; } = RulesetVersion.Dnd5e_2024;

		//	True if the data belongs to the official SRD, false if Homebrew
		public bool IsOfficialSRD { get; set; } = false;

		//	If null, it represents base system content; otherwise, it stores the author identifier
		public string? AuthorId { get; set; }
	}
}