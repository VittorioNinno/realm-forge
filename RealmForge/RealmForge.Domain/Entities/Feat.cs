using RealmForge.Domain.Common;
using RealmForge.Domain.Enums;

namespace RealmForge.Domain.Entities
{
	public class Feat : GameEntity
	{
		public FeatCategory Category { get; set; } = FeatCategory.General;
		public string? Prerequisite { get; set; }

		public ICollection<FeatTranslation> Translations { get; set; } = new List<FeatTranslation>();
	}

	public class FeatTranslation
	{
		public Guid Id { get; set; } = Guid.NewGuid();

		public Guid FeatId { get; set; }
		public Feat Feat { get; set; } = null!;

		public LanguageCode Language { get; set; }

		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
	}
}