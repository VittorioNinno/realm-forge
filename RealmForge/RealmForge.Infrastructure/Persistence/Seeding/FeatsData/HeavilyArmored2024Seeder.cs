using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Heavily Armored feat (2024 ruleset).
///	</summary>
public static class HeavilyArmored2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555568");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551181");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551182");

	///	<summary>
	///	Asynchronously seeds the Heavily Armored feat if it does not already exist.
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
					Name = "Heavily Armored",
					Description = "You gain the following benefits:\n- **Ability Score Increase.** Increase your Constitution or Strength score by 1, to a maximum of 20.\n- **Armor Training.** You gain training with Heavy armor."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Corazze Pesanti",
					Description = "Il personaggio ottiene i seguenti benefici:\n- **Incremento dei Punteggi di Caratteristica.** Il suo punteggio di Costituzione o Forza aumenta di 1, fino a un massimo di 20.\n- **Competenza nelle Armature.** Il personaggio ottiene competenza nelle armature pesanti."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}