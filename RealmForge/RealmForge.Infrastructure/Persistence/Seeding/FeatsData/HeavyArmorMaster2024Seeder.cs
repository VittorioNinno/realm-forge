using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Heavy Armor Master feat (2024 ruleset).
///	</summary>
public static class HeavyArmorMaster2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555569");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551191");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551192");

	///	<summary>
	///	Asynchronously seeds the Heavy Armor Master feat if it does not already exist.
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
			Prerequisite = "Level 4+, Heavy Armor Training",
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Heavy Armor Master",
					Description = "You gain the following benefits:\n- **Ability Score Increase.** Increase your Constitution or Strength score by 1, to a maximum of 20.\n- **Damage Reduction.** When you're hit by an attack while you're wearing Heavy armor, any Bludgeoning, Piercing, and Slashing damage dealt to you by that attack is reduced by an amount equal to your Proficiency Bonus."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Maestro delle Armature Pesanti",
					Description = "Il personaggio ottiene i seguenti benefici:\n- **Incremento dei Punteggi di Caratteristica.** Il suo punteggio di Costituzione o Forza aumenta di 1, fino a un massimo di 20.\n- **Riduzione dei Danni.** Quando il personaggio viene colpito da un attacco mentre indossa un'armatura pesante, eventuali danni contundenti, perforanti o taglienti subiti vengono ridotti di un valore pari al suo bonus di competenza."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}