using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Keen Mind feat (2024 ruleset).
///	</summary>
public static class KeenMind2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555571");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551211");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551212");

	///	<summary>
	///	Asynchronously seeds the Keen Mind feat if it does not already exist.
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
			Prerequisite = "Level 4+, Intelligence 13+",
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Keen Mind",
					Description = "You gain the following benefits:\n- **Ability Score Increase.** Increase your Intelligence score by 1, to a maximum of 20.\n- **Lore Knowledge.** Choose one of the following skills: Arcana, History, Investigation, Nature, or Religion. If you lack proficiency in the chosen skill, you gain proficiency in it, and if you already have proficiency in it, you gain Expertise in it.\n- **Quick Study.** You can take the Study action as a Bonus Action."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Mente Acuta",
					Description = "Il personaggio ottiene i seguenti benefici:\n- **Incremento dei Punteggi di Caratteristica.** Il suo punteggio di Intelligenza aumenta di 1, fino a un massimo di 20.\n- **Conoscenza Profonda.** Il personaggio sceglie una tra le seguenti abilità: Arcano, Indagare, Natura, Religione o Storia. Ottiene competenza nell'abilità scelta se non la possiede, e Maestria se invece la possiede già.\n- **Studio Celere.** Il personaggio può utilizzare l'azione Studio come Azione Bonus."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}