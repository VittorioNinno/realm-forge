using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Spell Sniper feat (2024 ruleset).
///	</summary>
public static class SpellSniper2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555592");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551421");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551422");

	///	<summary>
	///	Asynchronously seeds the Spell Sniper feat if it does not already exist.
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
					Name = "Spell Sniper",
					Description = "You gain the following benefits:\n- **Ability Score Increase.** Increase your Intelligence, Wisdom, or Charisma score by 1, to a maximum of 20.\n- **Bypass Cover.** Your attack rolls for spells ignore Half Cover and Three-Quarters Cover.\n- **Casting in Melee.** Being within 5 feet of an enemy doesn't impose Disadvantage on your attack rolls with spells.\n- **Increased Range.** When you cast a spell that has a range of at least 10 feet and requires you to make an attack roll, you can increase the spell's range by 60 feet."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Cecchino Magico",
					Description = "Il personaggio ottiene i seguenti benefici:\n- **Incremento dei Punteggi di Caratteristica.** Il suo punteggio di Intelligenza, Saggezza o Carisma aumenta di 1, fino a un massimo di 20.\n- **Ignora Copertura.** I tiri per colpire del personaggio per gli incantesimi ignorano la mezza copertura e i tre quarti di copertura.\n- **Lancio in Mischia.** Anche se il personaggio si trova a 1,5 metri da un nemico, non subisce Svantaggio ai tiri per colpire con gli incantesimi.\n- **Gittata Aumentata.** Quando il personaggio lancia un incantesimo con una gittata di almeno 3 metri e che richiede di effettuare un tiro per colpire, può aumentare tale gittata di 18 metri."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}