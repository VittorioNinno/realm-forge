using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Lightly Armored feat (2014 ruleset).
///	</summary>
public static class LightlyArmored2014Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555519");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555691");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555692");

	///	<summary>
	///	Asynchronously seeds the Lightly Armored feat if it does not already exist.
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
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Lightly Armored",
					Description = "You have trained to master the use of light armor, gaining the following benefits:\n- Increase your Strength or Dexterity score by 1, to a maximum of 20.\n- You gain proficiency with light armor."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Corazze Leggere",
					Description = "Il personaggio si è addestrato per padroneggiare l'utilizzo delle armature leggere e ottiene i benefici seguenti:\n- Il suo punteggio di Forza o di Destrezza aumenta di 1, fino a un massimo di 20.\n- Ottiene competenza nelle armature leggere."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}