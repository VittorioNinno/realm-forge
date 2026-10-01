using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Skilled feat (2024 ruleset).
///	</summary>
public static class Skilled2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555551");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551011");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551012");

	///	<summary>
	///	Asynchronously seeds the Skilled feat if it does not already exist.
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
					Name = "Skilled",
					Description = "You gain proficiency in any combination of three skills or tools of your choice.\n- **Repeatable.** You can take this feat more than once."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Abile",
					Description = "Il personaggio ottiene competenza in una combinazione di tre abilità o strumenti a scelta.\n- **Ripetibile.** Questo talento è ottenibile più di una volta."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}