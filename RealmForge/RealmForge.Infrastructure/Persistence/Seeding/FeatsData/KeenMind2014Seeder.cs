using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Keen Mind feat (2014 ruleset).
///	</summary>
public static class KeenMind2014Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555518");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555681");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555682");

	///	<summary>
	///	Asynchronously seeds the Keen Mind feat if it does not already exist.
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
					Name = "Keen Mind",
					Description = "You have a mind that can track time, direction, and detail with uncanny precision. You gain the following benefits:\n- Increase your Intelligence score by 1, to a maximum of 20.\n- You always know which way is north.\n- You always know the number of hours left before the next sunrise or sunset.\n- You can accurately recall anything you have seen or heard within the past month."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Mente Acuta",
					Description = "La mente del personaggio è in grado di tenere conto del tempo, della direzione e dei dettagli con straordinaria precisione. Il personaggio ottiene i benefici seguenti:\n- Il suo punteggio di Intelligenza aumenta di 1, fino a un massimo di 20.\n- Sa sempre in che direzione si trova il nord.\n- Sa sempre quante ore mancano alla prossima alba o al prossimo tramonto.\n- Riesce a ricordare con precisione tutto ciò che ha visto o sentito nell'arco dell'ultimo mese."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}