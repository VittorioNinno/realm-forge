using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Martial Weapon Training feat (2024 ruleset).
///	</summary>
public static class MartialWeaponTraining2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555574");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551241");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551242");

	///	<summary>
	///	Asynchronously seeds the Martial Weapon Training feat if it does not already exist.
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
					Name = "Martial Weapon Training",
					Description = "You gain the following benefits:\n- **Ability Score Increase.** Increase your Strength or Dexterity score by 1, to a maximum of 20.\n- **Weapon Proficiency.** You gain proficiency with Martial weapons."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Competenza nelle Armi da Guerra",
					Description = "Il personaggio ottiene i seguenti benefici:\n- **Incremento dei Punteggi di Caratteristica.** Il suo punteggio di Forza o Destrezza aumenta di 1, fino a un massimo di 20.\n- **Competenza nelle Armi.** Il personaggio ottiene competenza nelle armi da guerra."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}