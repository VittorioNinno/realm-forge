using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Crafter feat (2024 ruleset) with Markdown tables.
///	</summary>
public static class Crafter2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555545");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555951");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555952");

	///	<summary>
	///	Asynchronously seeds the Crafter feat if it does not already exist.
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
			Category = FeatCategory.Origin,
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Crafter",
					Description = "You gain the following benefits:\n- Tool Proficiency. You gain proficiency with three different Artisan's Tools of your choice from the Fast Crafting table.\n- Discount. Whenever you buy a nonmagical item, you receive a 20 percent discount on it.\n- Fast Crafting. When you finish a Long Rest, you can craft one piece of gear from the Fast Crafting table, provided you have the Artisan's Tools associated with that item and have proficiency with those tools. The item lasts until you finish another Long Rest, at which point the item falls apart.\n\n### Fast Crafting Table\n| Artisan's Tools | Crafted Gear |\n|---|---|\n| Carpenter's Tools | Ladder, Torch |\n| Leatherworker's Tools | Crossbow Bolt Case, Map or Scroll Case, Pouch |\n| Mason's Tools | Block and Tackle |\n| Potter's Tools | Jug, Lamp |\n| Smith's Tools | Ball Bearings, Bucket, Caltrops, Grappling Hook, Iron Pot |\n| Tinker's Tools | Bell, Shovel, Tinderbox |\n| Weaver's Tools | Basket, Rope, Net, Tent |\n| Woodcarver's Tools | Club, Greatclub, Quarterstaff |"
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Lavoro Manuale",
					Description = "Il personaggio ottiene i seguenti benefici:\n- Competenza negli Strumenti. Il personaggio ottiene competenza in tre diversi strumenti da artigiano a scelta dalla tabella Fabbricazione Rapida.\n- Sconto. Ogni volta che il personaggio acquista un oggetto non magico, ottiene il 20% di sconto.\n- Fabbricazione Rapida. Quando il personaggio completa un riposo lungo, può realizzare uno strumento a scelta dalla tabella Fabbricazione Rapida, ammesso che abbia gli strumenti da artigiano necessari e ne possieda la competenza. Gli oggetti durano fino al completamento di un altro riposo lungo, per poi rompersi.\n\n### Tabella Fabbricazione Rapida\n| Strumenti da artigiano | Attrezzatura creata |\n|---|---|\n| Strumenti da conciatore | Custodia, borsa |\n| Strumenti da fabbro | Sfera metallica, secchio, triboli, rampino, pentola di ferro |\n| Strumenti da falegname | Scala a pioli, torcia |\n| Strumenti da intagliatore | Randello, randello pesante, bastone ferrato |\n| Strumenti da inventore | Campanella, pala, acciarino con pietra focaia |\n| Strumenti da muratore | Carrucola e paranco |\n| Strumenti da tessitore | Cesto, corda, rete, tenda |\n| Strumenti da vasaio | Brocca, lampada |"
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}