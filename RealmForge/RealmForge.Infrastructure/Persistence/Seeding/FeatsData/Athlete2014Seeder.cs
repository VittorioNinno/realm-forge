using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Athlete feat (2014 ruleset).
///	</summary>
public static class Athlete2014Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555503");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555531");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555532");

	///	<summary>
	///	Asynchronously seeds the Athlete feat if it does not already exist.
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
					Name = "Athlete",
					Description = "You gain the following benefits:\n- Increase Strength or Dexterity by 1, to a maximum of 20.\n- Standing up from prone costs only 5 feet of movement.\n- Climbing does not halve your speed.\n- You can make a running long jump or running high jump after moving just 5 feet on foot, rather than 10 feet."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Atleta",
					Description = "Ottieni i seguenti benefici:\n- Aumenta il punteggio di Forza o Destrezza di 1, fino a un massimo di 20.\n- Alzarsi dalla condizione di prono richiede solo 1,5 metri di movimento.\n- Scalare non dimezza la velocità.\n- Puoi effettuare un salto in lungo o in alto con rincorsa muovendoti di soli 1,5 metri, anziché 3 metri."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}