using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Interception feat (2024 ruleset).
///	</summary>
public static class Interception2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555602");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551521");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551522");

	///	<summary>
	///	Asynchronously seeds the Interception feat if it does not already exist.
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
					Name = "Interception",
					Description = "When a creature you can see hits another creature within 5 feet of you with an attack roll, you can take a Reaction to reduce the damage dealt to the target by 1d10 plus your Proficiency Bonus. You must be holding a Shield or a Simple or Martial weapon to use this Reaction."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Intercettazione",
					Description = "Quando una creatura che il personaggio è in grado di vedere ne colpisce un'altra entro 1,5 metri da lui con un tiro per colpire, il personaggio può utilizzare una Reazione per ridurre i danni inflitti al bersaglio di 1d10 più il suo Bonus di Competenza. Per poter utilizzare questa Reazione, il personaggio deve impugnare uno Scudo o un'arma Semplice o da Guerra."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}