using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Skill Expert feat (2024 ruleset).
///	</summary>
public static class SkillExpert2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555588");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551381");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551382");

	///	<summary>
	///	Asynchronously seeds the Skill Expert feat if it does not already exist.
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
					Name = "Skill Expert",
					Description = "You gain the following benefits:\n- **Ability Score Increase.** Increase one ability score of your choice by 1, to a maximum of 20.\n- **Skill Proficiency.** You gain proficiency in one skill of your choice.\n- **Expertise.** Choose one skill in which you have proficiency but lack Expertise. You gain Expertise with that skill."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Abilità Impeccabile",
					Description = "Il personaggio ottiene i seguenti benefici:\n- **Incremento dei Punteggi di Caratteristica.** Il punteggio di una caratteristica a sua scelta aumenta di 1, fino a un massimo di 20.\n- **Competenza nelle Abilità.** Il personaggio acquisisce competenza in un'abilità a sua scelta.\n- **Maestria.** Il personaggio sceglie un'abilità in cui ha competenza, ma non Maestria, così da ottenere quest'ultima."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}