using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Great Weapon Master feat (2024 ruleset).
///	</summary>
public static class GreatWeaponMaster2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555567");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551171");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551172");

	///	<summary>
	///	Asynchronously seeds the Great Weapon Master feat if it does not already exist.
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
			Prerequisite = "Level 4+, Strength 13+",
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Great Weapon Master",
					Description = "You gain the following benefits:\n- **Ability Score Increase.** Increase your Strength score by 1, to a maximum of 20.\n- **Heavy Weapon Mastery.** When you hit a creature with a weapon that has the Heavy property as part of the Attack action on your turn, you can cause the weapon to deal extra damage to the target. The extra damage equals your Proficiency Bonus.\n- **Hew.** Immediately after you score a Critical Hit with a Melee weapon or reduce a creature to 0 Hit Points with one, you can make one attack with the same weapon as a Bonus Action."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Maestro d'Armi Possenti",
					Description = "Il personaggio ottiene i seguenti benefici:\n- **Incremento dei Punteggi di Caratteristica.** Il suo punteggio di Forza aumenta di 1, fino a un massimo di 20.\n- **Padronanza delle Armi Pesanti.** Quando il personaggio colpisce una creatura con un'arma Pesante come parte di un'azione di Attacco nel proprio turno, può far sì che l'arma infligga danni extra al bersaglio pari al suo bonus di competenza.\n- **Abbattimento.** Subito dopo aver messo a segno un colpo critico o aver ridotto una creatura a 0 punti ferita con un'arma da mischia, il personaggio può eseguire un attacco con quella stessa arma come Azione Bonus."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}