using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Dueling feat (2024 ruleset).
///	</summary>
public static class Dueling2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555600");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551501");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551502");

	///	<summary>
	///	Asynchronously seeds the Dueling feat if it does not already exist.
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
					Name = "Dueling",
					Description = "When you're holding a Melee weapon in one hand and no other weapons, you gain a +2 bonus to damage rolls with that weapon."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Duellare",
					Description = "Quando il personaggio impugna un'arma da mischia in una mano e nessun'altra arma, ottiene un bonus di +2 ai tiri per i danni con quell'arma."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}