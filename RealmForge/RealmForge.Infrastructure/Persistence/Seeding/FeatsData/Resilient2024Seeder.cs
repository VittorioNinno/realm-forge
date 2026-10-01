using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Resilient feat (2024 ruleset).
///	</summary>
public static class Resilient2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555582");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551321");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551322");

	///	<summary>
	///	Asynchronously seeds the Resilient feat if it does not already exist.
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
					Name = "Resilient",
					Description = "You gain the following benefits:\n- **Ability Score Increase.** Choose one ability in which you lack saving throw proficiency. Increase the chosen ability score by 1, to a maximum of 20.\n- **Saving Throw Proficiency.** You gain saving throw proficiency with the chosen ability."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Resiliente",
					Description = "Il personaggio ottiene i seguenti benefici:\n- **Incremento dei Punteggi di Caratteristica.** Il personaggio sceglie una caratteristica in cui non ha la relativa competenza nei tiri salvezza. Aumenta il punteggio di 1, fino a un massimo di 20.\n- **Competenza nei Tiri Salvezza.** Il personaggio ottiene competenza nei tiri salvezza con la caratteristica selezionata."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}