using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Chef feat (2024 ruleset).
///	</summary>
public static class Chef2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555558");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551081");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551082");

	///	<summary>
	///	Asynchronously seeds the Chef feat if it does not already exist.
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
			Prerequisite = "Level 4+",
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Chef",
					Description = "You gain the following benefits:\n- **Ability Score Increase.** Increase your Constitution or Wisdom score by 1, to a maximum of 20.\n- **Cook's Utensils.** You gain proficiency with Cook's Utensils if you don't already have it.\n- **Replenishing Meal.** As part of a Short Rest, you can cook special food if you have ingredients and Cook's Utensils on hand. You can prepare enough of this food for a number of creatures equal to 4 plus your Proficiency Bonus. At the end of the Short Rest, any creature who eats the food and spends one or more Hit Dice to regain Hit Points regains an extra 1d8 Hit Points.\n- **Bolstering Treats.** With 1 hour of work or when you finish a Long Rest, you can cook a number of treats equal to your Proficiency Bonus if you have ingredients and Cook's Utensils on hand. These special treats last 8 hours after being made. A creature can use a Bonus Action to eat one of those treats to gain a number of Temporary Hit Points equal to your Proficiency Bonus."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Cuoco",
					Description = "Il personaggio ottiene i seguenti benefici:\n- **Incremento dei Punteggi di Caratteristica.** Il suo punteggio di Costituzione o Saggezza aumenta di 1, fino a un massimo di 20.\n- **Utensili da Cuoco.** Ottiene competenza negli utensili da cuoco, se non la possiede già.\n- **Pasto Rifocillante.** Come parte di un riposo breve, può cucinare cibo speciale, a patto che abbia a disposizione gli ingredienti e gli utensili da cuoco. Può prepararne a sufficienza per un numero di creature pari a 4 più il suo bonus di competenza. Alla fine del riposo breve, ogni creatura che ha mangiato il cibo e spende uno o più Dadi Vita per recuperare punti ferita, recupera 1d8 punti ferita extra.\n- **Delizie Corroboranti.** Con un'ora di lavoro o alla fine di un riposo lungo, può cucinare un numero di delizie pari al suo bonus di competenza, se ha ingredienti e utensili da cuoco a portata di mano. Queste speciali delizie durano 8 ore dopo essere state preparate. Qualsiasi creatura che usi un'azione bonus per mangiarne una ottiene un numero di punti ferita temporanei pari al bonus di competenza del personaggio che le ha preparate."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}