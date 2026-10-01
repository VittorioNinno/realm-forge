using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Mobile feat (2014 ruleset).
///	</summary>
public static class Mobile2014Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555526");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555761");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555762");

	///	<summary>
	///	Asynchronously seeds the Mobile feat if it does not already exist.
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
					Name = "Mobile",
					Description = "You are exceptionally speedy and agile. You gain the following benefits:\n- Your speed increases by 10 feet.\n- When you use the Dash action, difficult terrain doesn't cost you extra movement on that turn.\n- When you make a melee attack against a creature, you don't provoke opportunity attacks from that creature for the rest of the turn, whether you hit or not."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Mobilità",
					Description = "Il personaggio è straordinariamente agile e veloce, e ottiene i benefici seguenti:\n- La sua velocità aumenta di 3 metri.\n- Quando usa l'azione di Scatto, il terreno difficile non gli costa movimento extra in quel turno.\n- Quando effettua un attacco in mischia contro una creatura, non provoca attacchi di opportunità da parte di quella creatura per il resto del turno, che l'attacco colpisca o meno."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}