using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

/// <summary>
/// Provides deterministic database seeding for the Defensive Duelist feat (2024 ruleset).
/// </summary>
public static class DefensiveDuelist2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555561");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551111");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551112");

	/// <summary>
	/// Asynchronously seeds the Defensive Duelist feat if it does not already exist.
	/// </summary>
	/// <param name="context">The database context instance.</param>
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
			Prerequisite = "Level 4+, Dexterity 13+",
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Defensive Duelist",
					Description = "You gain the following benefits:\n- **Ability Score Increase.** Increase your Dexterity score by 1, to a maximum of 20.\n- **Parry.** If you're holding a Finesse weapon and another creature hits you with a melee attack, you can take a Reaction to add your Proficiency Bonus to your Armor Class, potentially causing the attack to miss you. You gain this bonus to your AC against melee attacks until the start of your next turn."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Duellante Difensivo",
					Description = "Il personaggio ottiene i seguenti benefici:\n- **Incremento dei Punteggi di Caratteristica.** Il suo punteggio di Destrezza aumenta di 1, fino a un massimo di 20.\n- **Parata.** Quando il personaggio impugna un'arma Accurata e viene colpito con un attacco in mischia da un'altra creatura, può usare una Reazione per aggiungere il proprio bonus di competenza alla sua Classe Armatura, aumentando le probabilità che il colpo non vada a segno. Dopodiché, il bonus alla CA contro gli attacchi in mischia rimane fino all'inizio del suo turno successivo."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}