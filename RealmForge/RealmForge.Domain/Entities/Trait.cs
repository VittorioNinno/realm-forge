using RealmForge.Domain.Common;
using RealmForge.Domain.Enums;

namespace RealmForge.Domain.Entities
{
	public class Trait : GameEntity
	{
		//	Character level required to unlock this trait (defaults to 1)
		public int RequiredLevel { get; set; } = 1;

		//	Optional foreign key and navigation property if the trait belongs to a base species (e.g., Darkvision, Fey Ancestry)
		public Guid? SpeciesId { get; set; }
		public Species? Species { get; set; }

		//	Optional foreign key and navigation property if the trait belongs to a specific subspecies / lineage (e.g., Fleet of Foot, Drow Magic)
		public Guid? SubspeciesId { get; set; }
		public Subspecies? Subspecies { get; set; }

		//	Collection of localized texts for this trait
		public ICollection<TraitTranslation> Translations { get; set; } = new List<TraitTranslation>();
	}

	public class TraitTranslation
	{
		public Guid Id { get; set; } = Guid.NewGuid();

		public Guid TraitId { get; set; }
		public Trait Trait { get; set; } = null!;

		public LanguageCode Language { get; set; }

		//	Localized fields
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
	}
}