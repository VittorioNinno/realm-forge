using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Boon of Skill feat (2024 ruleset).
///	</summary>
public static class BoonOfSkill2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555614");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551641");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551642");

	///	<summary>
	///	Asynchronously seeds the Boon of Skill feat if it does not already exist.
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
					Name = "Boon of Skill",
					Description = "You gain the following benefits:\n- **Ability Score Increase.** Increase one ability score of your choice by 1, to a maximum of 30.\n- **All-Around Adept.** You gain proficiency in all skills.\n- **Expertise.** Choose one skill in which you lack Expertise. You gain Expertise in that skill."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Dono dell'Abilità",
					Description = "Il personaggio ottiene i seguenti benefici:\n- **Incremento dei Punteggi di Caratteristica.** Il punteggio di una sua caratteristica a scelta aumenta di 1, fino a un massimo di 30.\n- **Adepto Eclettico.** Il personaggio ottiene competenza in tutte le Abilità.\n- **Maestria.** Il personaggio sceglie un'Abilità in cui non possiede Maestria. Ottiene Maestria in quell'Abilità."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}