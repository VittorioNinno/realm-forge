using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Tavern Brawler feat (2024 ruleset).
///	</summary>
public static class TavernBrawler2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555552");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551021");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551022");

	///	<summary>
	///	Asynchronously seeds the Tavern Brawler feat if it does not already exist.
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
					Name = "Tavern Brawler",
					Description = "You gain the following benefits:\n- **Enhanced Unarmed Strike.** When you hit with your Unarmed Strike and deal damage, you can deal Bludgeoning damage equal to 1d4 plus your Strength modifier instead of the normal damage of an Unarmed Strike.\n- **Damage Rerolls.** Whenever you roll a damage die for your Unarmed Strike, you can reroll the die if it rolls a 1, and you must use the new roll.\n- **Improvised Weaponry.** You have proficiency with improvised weapons.\n- **Push.** When you hit a creature with an Unarmed Strike as part of the Attack action on your turn, you can deal damage to the target and also push it 5 feet away from you. You can use this benefit only once per turn."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Lottatore da Taverna",
					Description = "Il personaggio ottiene i seguenti benefici:\n- **Colpo Senz'armi Migliorato.** Quando il personaggio colpisce con un colpo senz'armi e infligge dei danni, può infliggere 1d4 danni contundenti più il suo modificatore di Forza invece dei normali danni del colpo senz'armi.\n- **Tiro Ripetuto per i Danni.** Quando il personaggio tira per i danni di un colpo senz'armi, se ottiene 1 può ripetere il tiro. Tuttavia, dovrà utilizzare il nuovo risultato.\n- **Armi Improvvisate.** Il personaggio ha competenza nelle armi improvvisate.\n- **Spinta.** Quando il personaggio colpisce una creatura con un colpo senz'armi come parte di un'azione di Attacco nel suo turno, può infliggere danni al bersaglio e spingerlo via di 1,5 metri da sé. Questo beneficio è utilizzabile una sola volta per turno."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}