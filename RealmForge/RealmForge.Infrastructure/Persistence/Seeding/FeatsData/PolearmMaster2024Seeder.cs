using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Polearm Master feat (2024 ruleset).
///	</summary>
public static class PolearmMaster2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555581");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551311");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551312");

	///	<summary>
	///	Asynchronously seeds the Polearm Master feat if it does not already exist.
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
					Name = "Polearm Master",
					Description = "You gain the following benefits:\n- **Ability Score Increase.** Increase your Dexterity or Strength score by 1, to a maximum of 20.\n- **Pole Strike.** Immediately after you take the Attack action and attack with a Quarterstaff, a Spear, or a weapon that has the Heavy and Reach properties, you can use a Bonus Action to make a melee attack with the opposite end of the weapon. The weapon deals Bludgeoning damage, and the weapon's damage die for this attack is a d4.\n- **Reactive Strike.** While you're holding a Quarterstaff, a Spear, or a weapon that has the Heavy and Reach properties, you can take a Reaction to make one melee attack against a creature that enters the reach you have with that weapon."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Maestro delle Armi su Asta",
					Description = "Il personaggio ottiene i seguenti benefici:\n- **Incremento dei Punteggi di Caratteristica.** Il suo punteggio di Destrezza o Forza aumenta di 1, fino a un massimo di 20.\n- **Colpo d'Asta.** Subito dopo aver effettuato l'azione di Attacco con un bastone ferrato, una lancia o un'arma con le proprietà Pesante e Portata, il personaggio può usare un'Azione Bonus per sferrare un attacco in mischia con l'estremità opposta dell'arma. Così facendo, infligge 1d4 danni contundenti.\n- **Colpo Reattivo.** Finché impugna un bastone ferrato, una lancia o un'arma con le proprietà Pesante e Portata, il personaggio può usare una Reazione per sferrare un attacco in mischia contro una creatura che entra nella portata che il personaggio ha con quell'arma."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}