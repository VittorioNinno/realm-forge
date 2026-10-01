using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Boon of Irresistible Offense feat (2024 ruleset).
///	</summary>
public static class BoonOfIrresistibleOffense2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555612");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551621");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551622");

	///	<summary>
	///	Asynchronously seeds the Boon of Irresistible Offense feat if it does not already exist.
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
					Name = "Boon of Irresistible Offense",
					Description = "You gain the following benefits:\n- **Ability Score Increase.** Increase your Strength or Dexterity score by 1, to a maximum of 30.\n- **Overcome Defenses.** The Bludgeoning, Piercing, and Slashing damage you deal always ignores Resistance.\n- **Overwhelming Strike.** When you roll a 20 on the d20 for an attack roll, you can deal extra damage to the target equal to the ability score increased by this feat. The extra damage's type is the same as the attack's type."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Dono dell'Offensiva Irresistibile",
					Description = "Il personaggio ottiene i seguenti benefici:\n- **Incremento dei Punteggi di Caratteristica.** Il suo punteggio di Forza o Destrezza aumenta di 1, fino a un massimo di 30.\n- **Ignora Difese.** I danni Contundenti, Perforanti e Taglienti inflitti dal personaggio ignorano sempre la Resistenza.\n- **Colpo Soverchiante.** Quando il personaggio tira per colpire con il d20 e ottiene un 20, può infliggere una quantità di danni extra al bersaglio pari al punteggio di caratteristica incrementato da questo talento. Il danno aggiuntivo è dello stesso tipo dell'attacco."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}