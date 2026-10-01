using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Observant feat (2014 ruleset).
///	</summary>
public static class Observant2014Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555529");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555791");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555792");

	///	<summary>
	///	Asynchronously seeds the Observant feat if it does not already exist.
	///	</summary>
	///	<param name="context">The database context instance.</param>
	public static async Task SeedAsync(RealmForgeDbContext context)
	{
		if (await context.Feats.AnyAsync(f => f.Id == FeatId))
		{
			return;
		}

		var feat = new Feat
		{
			Id = FeatId,
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Category = FeatCategory.General,
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Observant",
					Description = "Quick to notice details of your environment, you gain the following benefits:\n- Increase your Intelligence or Wisdom score by 1, to a maximum of 20.\n- If you can see a creature's mouth while it is speaking a language you understand, you can interpret what it's saying by reading its lips.\n- You have a +5 bonus to your passive Wisdom (Perception) and passive Intelligence (Investigation) scores."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Osservatore",
					Description = "Il personaggio nota rapidamente i dettagli dell'ambiente circostante e ottiene i benefici seguenti:\n- Il suo punteggio di Intelligenza o di Saggezza aumenta di 1, fino a un massimo di 20.\n- Se è in grado di vedere la bocca di una creatura mentre questa parla un linguaggio a lui conosciuto, riesce a capire cosa sta dicendo leggendo le labbra.\n- Ottiene un bonus di +5 alle sue prove passive di Saggezza (Percezione) e alle sue prove passive di Intelligenza (Indagare)."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}