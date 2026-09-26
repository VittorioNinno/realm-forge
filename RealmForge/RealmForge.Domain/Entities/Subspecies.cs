using RealmForge.Domain.Common;
using RealmForge.Domain.Enums;

namespace RealmForge.Domain.Entities
{
	public class Subspecies : GameEntity
	{
		//	Foreign key and navigation property to the parent Species
		public Guid SpeciesId { get; set; }
		public Species Species { get; set; } = null!;

		//	Optional base walking speed override in feet (e.g., 35 ft. for Wood Elf)
		public int? BaseSpeedOverrideInFeet { get; set; }

		//	Traits granted exclusively by this subspecies or lineage
		public ICollection<Trait> Traits { get; set; } = new List<Trait>();

		//	Localized name and description collection
		public ICollection<SubspeciesTranslation> Translations { get; set; } = new List<SubspeciesTranslation>();
	}

	public class SubspeciesTranslation
	{
		public Guid Id { get; set; } = Guid.NewGuid();

		public Guid SubspeciesId { get; set; }
		public Subspecies Subspecies { get; set; } = null!;

		public LanguageCode Language { get; set; }

		//	Localized fields
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
	}
}