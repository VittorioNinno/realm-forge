using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Shield Master feat (2024 ruleset).
///	</summary>
public static class ShieldMaster2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555587");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551371");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551372");

	///	<summary>
	///	Asynchronously seeds the Shield Master feat if it does not already exist.
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
			Prerequisite = "Level 4+, Shield Training",
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Shield Master",
					Description = "You gain the following benefits:\n- **Ability Score Increase.** Increase your Strength score by 1, to a maximum of 20.\n- **Shield Bash.** If you attack a creature within 5 feet of you as part of the Attack action and hit with a Melee weapon, you can immediately bash the target with your Shield if it's equipped, forcing the target to make a Strength saving throw (DC 8 plus your Strength modifier and Proficiency Bonus). On a failed save, you either push the target 5 feet from you or cause it to have the Prone condition (your choice). You can use this benefit only once on each of your turns.\n- **Interpose Shield.** If you're subjected to an effect that allows you to make a Dexterity saving throw to take only half damage, you can take a Reaction to take no damage if you succeed on the saving throw and are holding a Shield."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Maestro degli Scudi",
					Description = "Il personaggio ottiene i seguenti benefici:\n- **Incremento dei Punteggi di Caratteristica.** Il suo punteggio di Forza aumenta di 1, fino a un massimo di 20.\n- **Scudo da Sfondamento.** Se il personaggio attacca una creatura entro 1,5 metri da sé come parte dell'azione di Attacco e colpisce con un'arma da mischia, può subito colpire il bersaglio con lo scudo se questo è equipaggiato, costringendolo a effettuare un tiro salvezza su Forza (CD 8 più il modificatore di Forza e il bonus di competenza). In caso di fallimento, spinge via la creatura di 1,5 metri da sé o la fa cadere Prona (a sua scelta). Questo beneficio è utilizzabile una sola volta per turno.\n- **Interposizione di Scudo.** Se il personaggio è soggetto a un effetto che gli consente di effettuare un tiro salvezza su Destrezza per dimezzare i danni, può usare una Reazione per non subire alcun danno se supera il tiro salvezza e impugna uno scudo."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}