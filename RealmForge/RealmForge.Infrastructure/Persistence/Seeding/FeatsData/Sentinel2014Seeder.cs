using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Sentinel feat (2014 ruleset).
///	</summary>
public static class Sentinel2014Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555534");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555841");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555842");

	///	<summary>
	///	Asynchronously seeds the Sentinel feat if it does not already exist.
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
					Name = "Sentinel",
					Description = "You have mastered techniques to take advantage of every drop in any enemy's guard, gaining the following benefits:\n- When you hit a creature with an opportunity attack, the creature's speed becomes 0 for the rest of the turn.\n- Creatures within 5 feet of you provoke opportunity attacks from you even if they take the Disengage action before leaving your reach.\n- When a creature within 5 feet of you makes an attack against a target other than you (and that target doesn't have this feat), you can use your reaction to make a melee weapon attack against the attacking creature."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Sentinella",
					Description = "Il personaggio ha padroneggiato le tecniche che gli consentono di approfittare di ogni minuscolo varco nelle difese del nemico e ottiene i benefici seguenti:\n- Quando colpisce una creatura con un attacco di opportunità, la velocità di quella creatura diventa 0 per il resto del turno.\n- Le creature provocano attacchi di opportunità da parte sua anche quando effettuano l'azione di Disimpegno prima di uscire dalla sua portata.\n- Quando una creatura entro 1,5 metri dal personaggio effettua un attacco contro un bersaglio diverso da lui (e quel bersaglio non possiede questo talento), il personaggio può usare la sua reazione per effettuare un attacco con un'arma da mischia contro la creatura attaccante."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}