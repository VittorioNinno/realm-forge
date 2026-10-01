using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Sharpshooter feat (2024 ruleset).
///	</summary>
public static class Sharpshooter2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555586");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551361");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551362");

	///	<summary>
	///	Asynchronously seeds the Sharpshooter feat if it does not already exist.
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
			Prerequisite = "Level 4+, Dexterity 13+",
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Sharpshooter",
					Description = "You gain the following benefits:\n- **Ability Score Increase.** Increase your Dexterity score by 1, to a maximum of 20.\n- **Bypass Cover.** Your ranged attacks with weapons ignore Half Cover and Three-Quarters Cover.\n- **Firing in Melee.** Being within 5 feet of an enemy doesn't impose Disadvantage on your attack rolls with Ranged weapons.\n- **Long Shots.** Attacking at long range doesn't impose Disadvantage on your attack rolls with Ranged weapons."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Tiratore Scelto",
					Description = "Il personaggio ottiene i seguenti benefici:\n- **Incremento dei Punteggi di Caratteristica.** Il suo punteggio di Destrezza aumenta di 1, fino a un massimo di 20.\n- **Ignora Copertura.** Gli attacchi a distanza con le armi ignorano la mezza copertura e i tre quarti di copertura.\n- **Sparo in Mischia.** Anche se il personaggio si trova a 1,5 metri da un nemico, non subisce Svantaggio ai tiri per colpire con le armi a distanza.\n- **Tiri Lunghi.** Attaccare dalla lunga distanza non conferisce Svantaggio ai tiri per colpire con le armi a distanza."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}