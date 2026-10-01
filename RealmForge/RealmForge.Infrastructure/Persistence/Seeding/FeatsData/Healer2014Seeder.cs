using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Healer feat (2014 ruleset).
///	</summary>
public static class Healer2014Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555514");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555641");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555642");

	///	<summary>
	///	Asynchronously seeds the Healer feat if it does not already exist.
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
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Healer",
					Description = "You are an able physician, allowing you to mend wounds quickly and get your allies back in the fight. You gain the following benefits:\n- When you use a healer's kit to stabilize a dying creature, that creature also regains 1 hit point.\n- As an action, you can spend one use of a healer's kit to tend to a creature and restore 1d6 + 4 hit points to it, plus additional hit points equal to the creature's maximum number of Hit Dice. The creature can't regain hit points from this feat again until it finishes a short or long rest."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Guaritore",
					Description = "Il personaggio è un abile guaritore, in grado di medicare le ferite rapidamente e di consentire ai suoi alleati di tornare a combattere. Ottiene i benefici seguenti:\n- Quando usa una borsa del guaritore per stabilizzare una creatura morente, quella creatura recupera anche 1 punto ferita.\n- Con un'azione, può spendere un utilizzo della borsa del guaritore per curare una creatura e ripristinare 1d6 + 4 dei suoi punti ferita, più un numero di punti ferita aggiuntivi pari al massimo dei Dadi Vita della creatura. La creatura non può recuperare altri punti ferita tramite questo talento finché non completa un riposo breve o lungo."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}