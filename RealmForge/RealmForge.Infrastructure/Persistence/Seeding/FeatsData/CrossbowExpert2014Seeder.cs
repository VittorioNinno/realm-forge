using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Crossbow Expert feat (2014 ruleset).
///	</summary>
public static class CrossbowExpert2014Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555506");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555561");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555562");

	///	<summary>
	///	Asynchronously seeds the Crossbow Expert feat if it does not already exist.
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
					Name = "Crossbow Expert",
					Description = "Thanks to extensive practice with the crossbow, you gain the following benefits:\n- You ignore the loading quality of crossbows with which you are proficient.\n- Being within 5 feet of a hostile creature doesn't impose disadvantage on your ranged attack rolls.\n- When you use the Attack action and attack with a one-handed weapon, you can use a bonus action to attack with a loaded hand crossbow you are holding."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Esperto di Balestre",
					Description = "Grazie a un serrato addestramento nell'utilizzo della balestra, il personaggio ottiene i benefici seguenti:\n- Ignora la proprietà di ricarica delle balestre in cui possiede competenza.\n- La presenza di una creatura ostile a 1,5 metri da lui non impone svantaggio ai suoi tiri per colpire a distanza.\n- Quando usa l'azione di attacco per attaccare con un'arma a una mano, può usare un'azione bonus per attaccare con una balestra a mano da lui impugnata."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}