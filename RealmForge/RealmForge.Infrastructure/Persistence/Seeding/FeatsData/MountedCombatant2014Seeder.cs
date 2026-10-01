using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Mounted Combatant feat (2014 ruleset).
///	</summary>
public static class MountedCombatant2014Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555528");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555781");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555782");

	///	<summary>
	///	Asynchronously seeds the Mounted Combatant feat if it does not already exist.
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
					Name = "Mounted Combatant",
					Description = "You are a dangerous foe to face while mounted. While you are mounted and aren't incapacitated, you gain the following benefits:\n- You have advantage on melee attack rolls against any unmounted creature that is smaller than your mount.\n- You can force an attack targeted at your mount to target you instead.\n- If your mount is subjected to an effect that allows it to make a Dexterity saving throw to take only half damage, it instead takes no damage if it succeeds on the saving throw, and only half damage if it fails."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Combattente in Sella",
					Description = "Il personaggio è un nemico pericoloso da affrontare quando è in sella. Finché è in sella e non è incapacitato, ottiene i benefici seguenti:\n- Dispone di vantaggio ai tiri per colpire in mischia contro qualsiasi creatura che non sia a sua volta in sella e che sia più piccola della sua cavalcatura.\n- Può obbligare un attacco che bersaglierebbe la sua cavalcatura a bersagliare invece lui.\n- Se la sua cavalcatura è soggetta a un effetto che gli permette di effettuare un tiro salvezza su Destrezza per subire solo la metà dei danni, non subisce alcun danno se supera il tiro salvezza e soltanto la metà dei danni se lo fallisce."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}