using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Skulker feat (2024 ruleset).
///	</summary>
public static class Skulker2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555589");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551391");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551392");

	///	<summary>
	///	Asynchronously seeds the Skulker feat if it does not already exist.
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
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Category = FeatCategory.General,
			Prerequisite = "Level 4+, Dexterity 13+",
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Skulker",
					Description = "You gain the following benefits:\n- **Ability Score Increase.** Increase your Dexterity score by 1, to a maximum of 20.\n- **Blindsight.** You have Blindsight with a range of 10 feet.\n- **Fog of War.** You exploit the distractions of battle, gaining Advantage on any Dexterity (Stealth) check you make as part of the Hide action during combat.\n- **Sniper.** If you make an attack roll while hidden and the roll misses, making the attack roll doesn't reveal your location."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Appostato",
					Description = "Il personaggio ottiene i seguenti benefici:\n- **Incremento dei Punteggi di Caratteristica.** Il suo punteggio di Destrezza aumenta di 1, fino a un massimo di 20.\n- **Vista Cieca.** Il personaggio ottiene Vista Cieca con un raggio di 3 metri.\n- **Nebbia della Guerra.** Il personaggio è in grado di sfruttare le distrazioni della battaglia, ottenendo Vantaggio alle prove di Destrezza (Furtività) effettuate come parte dell'azione di Nascondersi durante il combattimento.\n- **Cecchino.** Se il personaggio effettua un tiro per colpire mentre è nascosto e il colpo manca il bersaglio, effettuare l'attacco non rivela la sua posizione."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}