using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Resilient feat (2014 ruleset).
///	</summary>
public static class Resilient2014Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555531");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555811");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555812");

	///	<summary>
	///	Asynchronously seeds the Resilient feat if it does not already exist.
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
					Name = "Resilient",
					Description = "Choose one ability score. You gain the following benefits:\n- Increase the chosen ability score by 1, to a maximum of 20.\n- You gain proficiency in saving throws using the chosen ability."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Resiliente",
					Description = "Il personaggio sceglie un punteggio di caratteristica e ottiene i benefici seguenti:\n- Il suo punteggio della caratteristica scelta aumenta di 1, fino a un massimo di 20.\n- Ottiene competenza nei tiri salvezza che usano la caratteristica scelta."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}