using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Unarmed Fighting feat (2024 ruleset).
///	</summary>
public static class UnarmedFighting2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555606");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551561");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551562");

	///	<summary>
	///	Asynchronously seeds the Unarmed Fighting feat if it does not already exist.
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
			Category = FeatCategory.FightingStyle,
			Prerequisite = "Fighting Style Feature",
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Unarmed Fighting",
					Description = "When you hit with your Unarmed Strike and deal damage, you can deal Bludgeoning damage equal to 1d6 plus your Strength modifier instead of the normal damage of an Unarmed Strike. If you aren't holding any weapons or a Shield when you make the attack roll, the d6 becomes a d8.\n\nAt the start of each of your turns, you can deal 1d4 Bludgeoning damage to one creature Grappled by you."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Combattere Disarmato",
					Description = "Quando il personaggio colpisce con un Colpo Senz'Armi e infligge danni, può infliggere danni Contundenti pari a 1d6 più il suo modificatore di Forza invece dei normali danni di un Colpo Senz'Armi. Se non impugna alcuna arma o Scudo quando effettua il tiro per colpire, il d6 diventa un d8.\n\nAll'inizio di ogni suo turno, il personaggio può infliggere 1d4 danni Contundenti a una creatura da lui Afferrata."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}