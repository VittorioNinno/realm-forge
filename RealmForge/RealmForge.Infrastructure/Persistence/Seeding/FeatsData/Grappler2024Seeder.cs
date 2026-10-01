using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Grappler feat (2024 ruleset).
///	</summary>
public static class Grappler2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555566");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551161");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551162");

	///	<summary>
	///	Asynchronously seeds the Grappler feat if it does not already exist.
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
			Prerequisite = "Level 4+, Strength or Dexterity 13+",
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Grappler",
					Description = "You gain the following benefits:\n- **Ability Score Increase.** Increase your Strength or Dexterity score by 1, to a maximum of 20.\n- **Punch and Grab.** When you hit a creature with an Unarmed Strike as part of the Attack action on your turn, you can use both the Damage and the Grapple option. You can use this benefit only once per turn.\n- **Attack Advantage.** You have Advantage on attack rolls against a creature Grappled by you.\n- **Fast Wrestler.** You don't have to spend extra movement to move a creature Grappled by you if the creature is your size or smaller."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Lottatore",
					Description = "Il personaggio ottiene i seguenti benefici:\n- **Incremento dei Punteggi di Caratteristica.** Il suo punteggio di Forza o Destrezza aumenta di 1, fino a un massimo di 20.\n- **Colpisci e Afferra.** Quando il personaggio colpisce una creatura con un colpo senz'armi come parte di un'azione di Attacco nel proprio turno, può scegliere se infliggerle danni o afferrarla. Questo beneficio è utilizzabile una sola volta per turno.\n- **Attacco con Vantaggio.** Il personaggio dispone di Vantaggio ai tiri per colpire contro le creature che ha afferrato.\n- **Lottatore Rapido.** Il personaggio non ha bisogno di spendere movimento extra se sposta una creatura che ha afferrato che sia della sua stessa categoria di taglia o inferiore."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}