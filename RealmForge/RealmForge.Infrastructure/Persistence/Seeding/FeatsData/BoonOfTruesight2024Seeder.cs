using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Boon of Truesight feat (2024 ruleset).
///	</summary>
public static class BoonOfTruesight2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555618");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551681");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551682");

	///	<summary>
	///	Asynchronously seeds the Boon of Truesight feat if it does not already exist.
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
			Category = FeatCategory.EpicBoon,
			Prerequisite = "Level 19+",
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Boon of Truesight",
					Description = "You gain the following benefits:\n- **Ability Score Increase.** Increase one ability score of your choice by 1, to a maximum of 30.\n- **Truesight.** You have Truesight with a range of 60 feet."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Dono della Vista Pura",
					Description = "Il personaggio ottiene i seguenti benefici:\n- **Incremento dei Punteggi di Caratteristica.** Il punteggio di una sua caratteristica a scelta aumenta di 1, fino a un massimo di 30.\n- **Vista Pura.** Il personaggio ottiene Vista Pura con un raggio di 18 metri."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}