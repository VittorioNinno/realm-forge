using RealmForge.Domain.Common;
using RealmForge.Domain.Enums;

namespace RealmForge.Domain.Entities
{
	public class Species : GameEntity
	{
		//	Language-invariant numerical and mechanical data
		public int BaseSpeedInFeet { get; set; } = 30;
		public CreatureType CreatureType { get; set; } = CreatureType.Humanoid;
		public List<CreatureSize> AllowedSizes { get; set; } = new() { CreatureSize.Medium };

		//	Collection of localized texts for this species
		public ICollection<SpeciesTranslation> Translations { get; set; } = new List<SpeciesTranslation>();

		//	Associated base traits and lineages / subspecies
		public ICollection<Trait> Traits { get; set; } = new List<Trait>();
		public ICollection<Subspecies> Subspecies { get; set; } = new List<Subspecies>();
	}

	public class SpeciesTranslation
	{
		public Guid Id { get; set; } = Guid.NewGuid();

		public Guid SpeciesId { get; set; }
		public Species Species { get; set; } = null!;

		public LanguageCode Language { get; set; }

		//	Localized fields
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
	}
}