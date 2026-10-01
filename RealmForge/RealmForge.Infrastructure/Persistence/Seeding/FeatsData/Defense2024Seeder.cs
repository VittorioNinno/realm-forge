using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Defense feat (2024 ruleset).
///	</summary>
public static class Defense2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555599");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551491");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551492");

	///	<summary>
	///	Asynchronously seeds the Defense feat if it does not already exist.
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
					Name = "Defense",
					Description = "While you're wearing Light, Medium, or Heavy armor, you gain a +1 bonus to Armor Class."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Difesa",
					Description = "Finché il personaggio indossa un'armatura Leggera, Media o Pesante, ottiene un bonus di +1 alla Classe Armatura."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}