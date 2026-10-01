using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Dual Wielder feat (2014 ruleset).
///	</summary>
public static class DualWielder2014Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555508");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555581");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555582");

	///	<summary>
	///	Asynchronously seeds the Dual Wielder feat if it does not already exist.
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
					Name = "Dual Wielder",
					Description = "You master fighting with two weapons, gaining the following benefits:\n- You gain a +1 bonus to AC while you are wielding a separate melee weapon in each hand.\n- You can use two-weapon fighting even when the one-handed melee weapons you are wielding aren't light.\n- You can draw or stow two one-handed weapons when you would normally be able to draw or stow only one."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Combattente a Due Armi",
					Description = "Il personaggio è un maestro nel combattimento con due armi e ottiene i benefici seguenti:\n- Ottiene un bonus di +1 alla CA mentre impugna un'arma da mischia separata in ogni mano.\n- Può combattere con due armi anche quando le armi da mischia a una mano che impugna non sono leggere.\n- Può estrarre o rinfoderare due armi a una mano quando normalmente sarebbe in grado di estrarne o rinfoderarne solo una."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}