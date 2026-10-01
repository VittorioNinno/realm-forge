using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Piercer feat (2024 ruleset).
///	</summary>
public static class Piercer2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555579");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551291");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551292");

	///	<summary>
	///	Asynchronously seeds the Piercer feat if it does not already exist.
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
					Name = "Piercer",
					Description = "You gain the following benefits:\n- **Ability Score Increase.** Increase your Strength or Dexterity by 1, to a maximum of 20.\n- **Puncture.** Once per turn, when you hit a creature with an attack that deals Piercing damage, you can reroll one of the attack's damage dice, and you must use the new roll.\n- **Enhanced Critical.** When you score a Critical Hit that deals Piercing damage to a creature, you can roll one additional damage die when determining the extra Piercing damage the target takes."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Stile Penetrante",
					Description = "Il personaggio ottiene i seguenti benefici:\n- **Incremento dei Punteggi di Caratteristica.** Il suo punteggio di Forza o Destrezza aumenta di 1, fino a un massimo di 20.\n- **Perforazione.** Una volta per turno, quando il personaggio colpisce una creatura con un attacco che infligge danni perforanti, può ripetere il tiro di uno dei dadi di danno e deve usare il nuovo risultato.\n- **Critico Migliorato.** Quando il personaggio mette a segno un colpo critico che infligge danni perforanti a una creatura, può tirare un dado di danno addizionale per determinare i danni perforanti extra subiti dal bersaglio."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}