using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Elemental Adept feat (2024 ruleset).
///	</summary>
public static class ElementalAdept2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555564");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551141");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551142");

	///	<summary>
	///	Asynchronously seeds the Elemental Adept feat if it does not already exist.
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
			Prerequisite = "Level 4+, Spellcasting or Pact Magic Feature",
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Elemental Adept",
					Description = "You gain the following benefits:\n- **Ability Score Increase.** Increase your Intelligence, Wisdom, or Charisma score by 1, to a maximum of 20.\n- **Energy Mastery.** Choose one of the following damage types: Acid, Cold, Fire, Lightning, or Thunder. Spells you cast ignore Resistance to damage of the chosen type. In addition, when you roll damage for a spell you cast that deals damage of that type, you can treat any 1 on a damage die as a 2.\n- **Repeatable.** You can take this feat more than once, but you must choose a different damage type each time for Energy Mastery."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Adepto Elementale",
					Description = "Il personaggio ottiene i seguenti benefici:\n- **Incremento dei Punteggi di Caratteristica.** Il suo punteggio di Intelligenza, Saggezza o Carisma aumenta di 1, fino a un massimo di 20.\n- **Padronanza dell'Energia.** Il personaggio sceglie uno dei tipi di danno seguenti: acido, freddo, fulmine, fuoco o tuono. Gli incantesimi lanciati dal personaggio ignorano un'eventuale resistenza al danno del tipo selezionato. Inoltre, quando effettua il tiro per i danni per un incantesimo che infligge danni di quella tipologia, può considerare ogni 1 come se fosse un 2.\n- **Ripetibile.** Questo talento è ottenibile più di una volta, ma per Padronanza dell'Energia deve scegliere un tipo di danno diverso ogni volta."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}