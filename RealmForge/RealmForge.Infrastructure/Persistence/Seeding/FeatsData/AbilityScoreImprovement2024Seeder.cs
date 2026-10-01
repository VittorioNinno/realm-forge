using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Ability Score Improvement feat (2024 ruleset).
///	</summary>
public static class AbilityScoreImprovement2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555554");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551041");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551042");

	///	<summary>
	///	Asynchronously seeds the Ability Score Improvement feat if it does not already exist.
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
					Name = "Ability Score Improvement",
					Description = "Increase one ability score of your choice by 2, or increase two ability scores of your choice by 1. This feat can't increase an ability score above 20.\n- **Repeatable.** You can take this feat more than once."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Aumento dei Punteggi di Caratteristica",
					Description = "Aumenta un punteggio di caratteristica a tua scelta di 2, oppure aumenta due punteggi di caratteristica di 1. Questo talento non può incrementare un punteggio di caratteristica oltre il 20.\n- **Ripetibile.** Questo talento è ottenibile più di una volta."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}