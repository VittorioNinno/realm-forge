using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Tough feat (2014 ruleset).
///	</summary>
public static class Tough2014Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555541");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555911");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555912");

	///	<summary>
	///	Asynchronously seeds the Tough feat if it does not already exist.
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
					Name = "Tough",
					Description = "Your hit point maximum increases by an amount equal to twice your level when you gain this feat. Whenever you gain a level thereafter, your hit point maximum increases by an additional 2 hit points."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Robusto",
					Description = "Il massimo dei punti ferita del personaggio aumenta di un ammontare pari al doppio del suo livello quando il personaggio ottiene questo talento. Da allora in poi, ogni volta che il personaggio acquisisce un livello, il massimo dei suoi punti ferita aumenta di 2 punti ferita aggiuntivi."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}