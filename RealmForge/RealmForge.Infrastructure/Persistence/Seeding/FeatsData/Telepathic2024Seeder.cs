using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Telepathic feat (2024 ruleset).
///	</summary>
public static class Telepathic2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555594");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551441");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551442");

	///	<summary>
	///	Asynchronously seeds the Telepathic feat if it does not already exist.
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
					Name = "Telepathic",
					Description = "You gain the following benefits:\n- **Ability Score Increase.** Increase your Intelligence, Wisdom, or Charisma score by 1, to a maximum of 20.\n- **Telepathic Utterance.** You can speak telepathically to any creature you can see within 60 feet of yourself. Your telepathic utterances are in a language you know, and the creature understands you only if it knows that language. Your communication doesn't give the creature the ability to respond to you telepathically.\n- **Detect Thoughts.** You always have the Detect Thoughts spell prepared. You can cast it without a spell slot or spell components, and you must finish a Long Rest before you can cast it in this way again. You can also cast it using spell slots you have of the appropriate level. Your spellcasting ability for the spell is the ability increased by this feat."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Telepatia",
					Description = "Il personaggio ottiene i seguenti benefici:\n- **Incremento dei Punteggi di Caratteristica.** Il suo punteggio di Intelligenza, Saggezza o Carisma aumenta di 1, fino a un massimo di 20.\n- **Conversazione Telepatica.** Il personaggio può parlare telepaticamente con qualsiasi creatura nel suo campo visivo entro 18 metri di distanza. Il personaggio può comunicare in una lingua che conosce e la creatura può comprenderlo solo se parla lo stesso linguaggio. La creatura, inoltre, non può rispondere telepaticamente al personaggio.\n- **Individuazione dei Pensieri.** L'incantesimo Individuazione dei Pensieri è sempre considerato preparato. Il personaggio può lanciarlo senza usare uno slot incantesimo o componenti, ma per poterlo fare di nuovo in questo modo deve completare un Riposo Lungo. Può anche lanciarlo usando gli slot a sua disposizione del livello appropriato. La caratteristica da incantatore per questo incantesimo è la caratteristica aumentata dal talento."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}