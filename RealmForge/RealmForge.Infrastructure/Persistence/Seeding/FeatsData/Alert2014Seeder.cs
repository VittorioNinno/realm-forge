using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

/// <summary>
/// Provides deterministic database seeding for the Alert feat (2014 ruleset).
/// </summary>
public static class Alert2014Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555502");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555521");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555522");

	/// <summary>
	/// Asynchronously seeds the Alert feat if it does not already exist.
	/// </summary>
	/// <param name="context">The database context instance.</param>
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
					Name = "Alert",
					Description = "Always on the lookout for danger, you gain the following benefits:\n- You gain a +5 bonus to initiative.\n- You can't be surprised while you are conscious.\n- Other creatures don't gain advantage on attack rolls against you as a result of being hidden from you."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Allerta",
					Description = "Il personaggio tiene sempre gli occhi aperti in caso di pericolo e ottiene i benefici seguenti:\n- Bonus di +5 all'iniziativa.\n- Non può essere sorpreso finché è cosciente.\n- Le altre creature non dispongono di vantaggio ai tiri per colpire contro di lui quando non sono viste da lui."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}