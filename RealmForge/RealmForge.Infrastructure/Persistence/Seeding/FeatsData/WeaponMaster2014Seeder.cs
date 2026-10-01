using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Weapon Master feat (2014 ruleset).
///	</summary>
public static class WeaponMaster2014Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555543");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555931");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555932");

	///	<summary>
	///	Asynchronously seeds the Weapon Master feat if it does not already exist.
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
					Name = "Weapon Master",
					Description = "You have practiced extensively with a variety of weapons, gaining the following benefits:\n- Increase your Strength or Dexterity score by 1, to a maximum of 20.\n- You gain proficiency with four weapons of your choice."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Maestro d'Armi",
					Description = "Il personaggio si è addestrato a lungo nell'utilizzo di molte armi e ottiene i benefici seguenti:\n- Il suo punteggio di Forza o di Destrezza aumenta di 1, fino a un massimo di 20.\n- Ottiene competenza in quattro armi a sua scelta. Ogni arma deve essere un'arma semplice o un'arma da guerra."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}