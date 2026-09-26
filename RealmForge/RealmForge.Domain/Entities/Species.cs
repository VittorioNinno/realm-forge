using RealmForge.Domain.Common;
using RealmForge.Domain.Enums;

namespace RealmForge.Domain.Entities;

public class Species : GameEntity
{
	//	Dati numerici e meccanici invarianti rispetto alla lingua
	public int BaseSpeedInFeet { get; set; } = 30;
	public string Size { get; set; } = "Medium";

	//	Collezione di testi localizzati per questa specie
	public ICollection<SpeciesTranslation> Translations { get; set; } = new List<SpeciesTranslation>();
}

public class SpeciesTranslation
{
	public Guid Id { get; set; } = Guid.NewGuid();

	public Guid SpeciesId { get; set; }
	public Species Species { get; set; } = null!;

	public LanguageCode Language { get; set; }

	//	Campi localizzati
	public string Name { get; set; } = string.Empty;
	public string Description { get; set; } = string.Empty;
}