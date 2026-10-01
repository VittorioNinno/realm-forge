using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Medium Armor Master feat (2024 ruleset).
///	</summary>
public static class MediumArmorMaster2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555575");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551251");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551252");

	///	<summary>
	///	Asynchronously seeds the Medium Armor Master feat if it does not already exist.
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
			Prerequisite = "Level 4+, Medium Armor Training",
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Medium Armor Master",
					Description = "You gain the following benefits:\n- **Ability Score Increase.** Increase your Strength or Dexterity score by 1, to a maximum of 20.\n- **Dexterous Wearer.** While you're wearing Medium armor, you can add 3, rather than 2, to your AC if you have a Dexterity score of 16 or higher."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Maestro delle Armature Medie",
					Description = "Il personaggio ottiene i seguenti benefici:\n- **Incremento dei Punteggi di Caratteristica.** Il suo punteggio di Forza o Destrezza aumenta di 1, fino a un massimo di 20.\n- **Agilità con Armatura.** Mentre indossa un'armatura media, il personaggio può aggiungere 3 alla sua CA (invece di 2) se ha un punteggio di Destrezza di 16 o superiore."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}