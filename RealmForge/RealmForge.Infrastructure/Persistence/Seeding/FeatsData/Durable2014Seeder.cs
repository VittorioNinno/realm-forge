using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Durable feat (2014 ruleset).
///	</summary>
public static class Durable2014Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555510");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555601");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555602");

	///	<summary>
	///	Asynchronously seeds the Durable feat if it does not already exist.
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
					Name = "Durable",
					Description = "Hardy and resilient, you gain the following benefits:\n- Increase your Constitution score by 1, to a maximum of 20.\n- When you roll a Hit Die to regain hit points, the minimum number of hit points you regain from the roll equals twice your Constitution modifier (minimum of 2)."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Tenace",
					Description = "Il personaggio è robusto e resiliente, e ottiene i benefici seguenti:\n- Il suo punteggio di Costituzione aumenta di 1, fino a un massimo di 20.\n- Quando tira un Dado Vita per recuperare punti ferita, il numero minimo di punti ferita che recupera con il tiro è pari al doppio del suo modificatore di Costituzione (fino a un minimo di 2)."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}