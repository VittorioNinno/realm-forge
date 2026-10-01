using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Slasher feat (2024 ruleset).
///	</summary>
public static class Slasher2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555590");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551401");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551402");

	///	<summary>
	///	Asynchronously seeds the Slasher feat if it does not already exist.
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
					Name = "Slasher",
					Description = "You gain the following benefits:\n- **Ability Score Increase.** Increase your Strength or Dexterity score by 1, to a maximum of 20.\n- **Hamstring.** Once per turn when you hit a creature with an attack that deals Slashing damage, you can reduce the Speed of that creature by 10 feet until the start of your next turn.\n- **Enhanced Critical.** When you score a Critical Hit that deals Slashing damage to a creature, it has Disadvantage on attack rolls until the start of your next turn."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Bisturi da Battaglia",
					Description = "Il personaggio ottiene i seguenti benefici:\n- **Incremento dei Punteggi di Caratteristica.** Il suo punteggio di Forza o Destrezza aumenta di 1, fino a un massimo di 20.\n- **Colpo Debilitante.** Una volta per turno, quando il personaggio colpisce una creatura con un attacco che infligge danni taglienti, può ridurre la velocità del bersaglio di 3 metri fino all'inizio del proprio turno successivo.\n- **Critico Migliorato.** Quando il personaggio mette a segno un colpo critico che infligge danni taglienti a una creatura, quest'ultima avrà Svantaggio ai tiri per colpire fino all'inizio del turno successivo del personaggio."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}