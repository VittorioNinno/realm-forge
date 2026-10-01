using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Sharpshooter feat (2014 ruleset).
///	</summary>
public static class Sharpshooter2014Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555535");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555851");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555852");

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
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Category = FeatCategory.General,
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Sharpshooter",
					Description = "You have mastered ranged weapons and can make shots that others find impossible. You gain the following benefits:\n- Attacking at long range doesn't impose disadvantage on your ranged weapon attack rolls.\n- Your ranged weapon attacks ignore half cover and three-quarters cover.\n- Before you make an attack with a ranged weapon that you are proficient with, you can choose to take a -5 penalty to the attack roll. If the attack hits, you add +10 to the attack's damage."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Tiratore Scelto",
					Description = "Il personaggio ha padroneggiato l'utilizzo delle armi a distanza ed è in grado di effettuare tiri che per gli altri risulterebbero impossibili. Ottiene i benefici seguenti:\n- Gli attacchi a gittata lunga non impongono svantaggio ai tiri per colpire delle sue armi a distanza.\n- Gli attacchi delle sue armi a distanza ignorano metà copertura e tre quarti di copertura.\n- Prima di effettuare un attacco con un'arma a distanza in cui è competente, può scegliere di subire una penalità di -5 al tiro per colpire. Se l'attacco colpisce, il personaggio aggiunge +10 ai danni dell'attacco."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}