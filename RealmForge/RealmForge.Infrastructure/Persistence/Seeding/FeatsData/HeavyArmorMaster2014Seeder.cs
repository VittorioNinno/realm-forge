using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Heavy Armor Master feat (2014 ruleset).
///	</summary>
public static class HeavyArmorMaster2014Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555516");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555661");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555662");

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
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Category = FeatCategory.General,
			Prerequisite = "Proficiency with heavy armor",
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Heavy Armor Master",
					Description = "You can use your armor to deflect strikes that would kill others. You gain the following benefits:\n- Increase your Strength score by 1, to a maximum of 20.\n- While you are wearing heavy armor, bludgeoning, piercing, and slashing damage that you take from non magical weapons is reduced by 3."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Maestro delle Armature Pesanti",
					Description = "Il personaggio può usare la sua armatura per deviare colpi che risulterebbero letali per gli altri. Ottiene i benefici seguenti:\n- Il suo punteggio di Forza aumenta di 1, fino a un massimo di 20.\n- Mentre indossa un'armatura pesante, i danni contundenti, perforanti e taglienti che subisce dalle armi non magiche sono ridotti di 3."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}