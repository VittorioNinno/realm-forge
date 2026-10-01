using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Mounted Combatant feat (2024 ruleset).
///	</summary>
public static class MountedCombatant2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555577");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551271");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551272");

	///	<summary>
	///	Asynchronously seeds the Mounted Combatant feat if it does not already exist.
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
					Name = "Mounted Combatant",
					Description = "You gain the following benefits:\n- **Ability Score Increase.** Increase your Strength, Dexterity, or Wisdom score by 1, to a maximum of 20.\n- **Mounted Strike.** While mounted, you have Advantage on attack rolls against any unmounted creature within 5 feet of your mount that is at least one size smaller than the mount.\n- **Leap Aside.** If your mount is subjected to an effect that allows it to make a Dexterity saving throw to take only half damage, it instead takes no damage if it succeeds on the saving throw and only half damage if it fails. For your mount to gain this benefit, you must be riding it, and neither of you can have the Incapacitated condition.\n- **Veer.** While mounted, you can force an attack that hits your mount to hit you instead if you don't have the Incapacitated condition."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Combattente in Sella",
					Description = "Il personaggio ottiene i seguenti benefici:\n- **Incremento dei Punteggi di Caratteristica.** Il suo punteggio di Forza, Destrezza o Saggezza aumenta di 1, fino a un massimo di 20.\n- **Colpo in Sella.** Finché il personaggio è in sella, ha Vantaggio ai tiri per colpire contro le creature non in sella entro 1,5 metri dalla sua cavalcatura, se queste sono almeno di una categoria di taglia inferiore rispetto a tale cavalcatura.\n- **Balzo Laterale.** Se la cavalcatura è soggetta a un effetto che le consente di effettuare un tiro salvezza su Destrezza per dimezzare i danni, non subisce alcun danno se supera il tiro salvezza, e soltanto la metà dei danni se lo fallisce. Affinché la cavalcatura disponga di questo beneficio, il personaggio deve starle in sella e nessuno dei due deve essere incapacitato.\n- **Deviazione.** Mentre è in sella, il personaggio può deviare contro di sé un attacco diretto alla propria cavalcatura, ammesso che non sia incapacitato."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}