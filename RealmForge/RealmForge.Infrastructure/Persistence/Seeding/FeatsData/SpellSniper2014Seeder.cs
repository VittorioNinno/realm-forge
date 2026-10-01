using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Spell Sniper feat (2014 ruleset).
///	</summary>
public static class SpellSniper2014Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555539");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555891");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555892");

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
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Category = FeatCategory.General,
			Prerequisite = "The ability to cast at least one spell",
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Spell Sniper",
					Description = "You have learned techniques to enhance your attacks with certain kinds of spells, gaining the following benefits:\n- When you cast a spell that requires you to make an attack roll, the spell's range is doubled.\n- Your ranged spell attacks ignore half cover and three-quarters cover.\n- You learn one cantrip that requires an attack roll. Choose the cantrip from the bard, cleric, druid, sorcerer, warlock, or wizard spell list. Your spellcasting ability for this cantrip depends on the spell list you chose from: Charisma for bard, sorcerer, or warlock; Wisdom for cleric or druid; or Intelligence for wizard."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Cecchino Magico",
					Description = "Il personaggio ha appreso le tecniche che gli consentono di potenziare i suoi attacchi con certi tipi di incantesimi e ottiene i benefici seguenti:\n- Quando lancia un incantesimo che gli richiede di effettuare un tiro per colpire, la gittata dell'incantesimo è raddoppiata.\n- Gli attacchi a distanza con un incantesimo ignorano metà copertura e tre quarti di copertura.\n- Apprende un trucchetto che richiede un tiro per colpire. Può sceglierlo dalle liste del bardo, chierico, druido, mago, stregone o warlock. La sua caratteristica da incantatore per questo trucchetto dipende dalla lista degli incantesimi da cui è stato scelto: Carisma per il bardo, lo stregone o il warlock; Saggezza per il chierico o il druido; Intelligenza per il mago."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}