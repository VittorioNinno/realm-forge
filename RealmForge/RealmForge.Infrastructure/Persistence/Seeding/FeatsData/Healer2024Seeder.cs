using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Healer feat (2024 ruleset).
///	</summary>
public static class Healer2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555546");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555961");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555962");

	///	<summary>
	///	Asynchronously seeds the Healer feat if it does not already exist.
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
			Category = FeatCategory.Origin,
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Healer",
					Description = "You gain the following benefits:\n- Battle Medic. If you have a Healer's Kit, you can expend one use of it and tend to a creature within 5 feet of yourself as a Utilize action. That creature can expend one of its Hit Point Dice, and you then roll that die. The creature regains a number of Hit Points equal to the roll plus your Proficiency Bonus.\n- Healing Rerolls. Whenever you roll a die to determine the number of Hit Points you restore with a spell or with this feat's Battle Medic benefit, you can reroll the die if it rolls a 1, and you must use the new roll."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Guaritore",
					Description = "Il personaggio ottiene i seguenti benefici:\n- Medico combattente. Se il personaggio ha con sé una borsa del guaritore, può consumare un uso con un'azione di Utilizzo per curare una creatura entro 1,5 metri da sé. Dopodiché, la creatura può spendere uno dei suoi Dadi Vita per effettuare un tiro. Così facendo, recupera un numero di punti ferita pari al risultato del tiro più il bonus di competenza del personaggio.\n- Tiro ripetuto per guarigione. Quando tiri un dado per determinare il numero di punti ferita ripristinati dal personaggio con un incantesimo o col beneficio Medico combattente fornito dal talento, puoi ripetere il tiro se ottieni 1. Tuttavia, dovrai utilizzare il nuovo risultato."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}