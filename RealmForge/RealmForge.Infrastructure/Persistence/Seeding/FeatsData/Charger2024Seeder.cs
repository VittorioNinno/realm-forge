using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Charger feat (2024 ruleset).
///	</summary>
public static class Charger2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555557");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551071");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551072");

	///	<summary>
	///	Asynchronously seeds the Charger feat if it does not already exist.
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
					Name = "Charger",
					Description = "You gain the following benefits:\n- **Ability Score Increase.** Increase your Strength or Dexterity score by 1, to a maximum of 20.\n- **Improved Dash.** When you take the Dash action, your Speed increases by 10 feet for that action.\n- **Charge Attack.** If you move at least 10 feet in a straight line toward a target immediately before hitting it with a melee attack roll as part of the Attack action, choose one of the following effects: gain a 1d8 bonus to the attack's damage roll, or push the target up to 10 feet away if it is no more than one size larger than you. You can use this benefit only once on each of your turns."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Carica",
					Description = "Il personaggio ottiene i seguenti benefici:\n- **Incremento dei Punteggi di Caratteristica.** Il suo punteggio di Forza o Destrezza aumenta di 1, fino a un massimo di 20.\n- **Scatto Migliorato.** Quando il personaggio effettua l'azione di Scatto, la sua velocità aumenta di 3 metri per quell'azione.\n- **Attacco in Carica.** Se il personaggio percorre almeno 3 metri in linea retta verso un bersaglio subito prima di colpirlo con un tiro per colpire in mischia come parte dell'azione di Attacco, sceglie uno dei seguenti effetti: ottiene 1d8 danni bonus al tiro per i danni, oppure spinge via il bersaglio di 3 metri se la sua taglia è superiore di massimo una categoria rispetto a quella del personaggio. Questo beneficio è utilizzabile una sola volta per turno."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}