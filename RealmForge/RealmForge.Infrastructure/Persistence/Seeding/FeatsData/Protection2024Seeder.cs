using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Protection feat (2024 ruleset).
///	</summary>
public static class Protection2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555603");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551531");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551532");

	///	<summary>
	///	Asynchronously seeds the Protection feat if it does not already exist.
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
					Name = "Protection",
					Description = "When a creature you can see attacks a target other than you that is within 5 feet of you, you can take a Reaction to interpose your Shield if you're holding one. You impose Disadvantage on the triggering attack roll and all other attack rolls against the target until the start of your next turn if you remain within 5 feet of the target."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Protezione",
					Description = "Quando una creatura che il personaggio è in grado di vedere attacca un bersaglio diverso dal personaggio entro 1,5 metri da lui, il personaggio può utilizzare una Reazione per proteggerlo con lo Scudo (se ne impugna uno). Così facendo, conferisce Svantaggio al tiro per colpire scatenante e a tutti gli altri tiri per colpire eseguiti contro quel bersaglio fino all'inizio del proprio turno successivo, se il personaggio rimane entro 1,5 metri dal bersaglio."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}