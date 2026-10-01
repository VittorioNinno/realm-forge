using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Heavily Armored feat (2014 ruleset).
///	</summary>
public static class HeavilyArmored2014Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555515");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555651");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555652");

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
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Category = FeatCategory.General,
			Prerequisite = "Proficiency with medium armor",
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Heavily Armored",
					Description = "You have trained to master the use of heavy armor, gaining the following benefits:\n- Increase your Strength score by 1, to a maximum of 20.\n- You gain proficiency with heavy armor."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Corazze Pesanti",
					Description = "Il personaggio si è addestrato per padroneggiare l'utilizzo delle armature pesanti e ottiene i benefici seguenti:\n- Il suo punteggio di Forza aumenta di 1, fino a un massimo di 20.\n- Ottiene competenza nelle armature pesanti."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}