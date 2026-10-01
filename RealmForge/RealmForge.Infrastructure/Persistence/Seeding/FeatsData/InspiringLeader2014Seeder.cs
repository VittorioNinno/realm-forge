using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Inspiring Leader feat (2014 ruleset).
///	</summary>
public static class InspiringLeader2014Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555517");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555671");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555672");

	///	<summary>
	///	Asynchronously seeds the Inspiring Leader feat if it does not already exist.
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
			Prerequisite = "Charisma 13 or higher",
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Inspiring Leader",
					Description = "You can spend 10 minutes inspiring your companions, shoring up their resolve to fight. When you do so, choose up to six friendly creatures (which can include yourself) within 30 feet of you who can see or hear you and who can understand you. Each creature can gain temporary hit points equal to your level + your Charisma modifier.\nA creature can't gain temporary hit points from this feat again until it has finished a short or long rest."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Condottiero Ispiratore",
					Description = "Il personaggio può dedicare 10 minuti a ispirare i suoi compagni, ravvivando la loro determinazione a combattere. Quando lo fa, sceglie fino a sei creature amiche (può includere se stesso) situate entro 9 metri da lui e che siano in grado di vederlo, di udirlo e di capirlo. Ogni creatura ottiene un numero di punti ferita temporanei pari al livello del personaggio + il modificatore di Carisma del personaggio.\nUna creatura non può ottenere altri punti ferita temporanei da questo talento finché non ha completato un riposo breve o lungo."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}