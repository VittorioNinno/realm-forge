using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Dungeon Delver feat (2014 ruleset).
///	</summary>
public static class DungeonDelver2014Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555509");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555591");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555592");

	///	<summary>
	///	Asynchronously seeds the Dungeon Delver feat if it does not already exist.
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
					Name = "Dungeon Delver",
					Description = "Alert to the hidden traps and secret doors found in many dungeons, you gain the following benefits:\n- You have advantage on Wisdom (Perception) and Intelligence (Investigation) checks made to detect the presence of secret doors.\n- You have advantage on saving throws made to avoid or resist traps.\n- You have resistance to the damage dealt by traps.\n- You can search for traps while traveling at a normal pace, instead of only at a slow pace."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Esperto di Dungeon",
					Description = "Il personaggio sa riconoscere le trappole nascoste e le porte segrete in molti dungeon e ottiene i benefici seguenti:\n- Dispone di vantaggio alle prove di Saggezza (Percezione) e Intelligenza (Indagare) effettuate per individuare la presenza di porte segrete.\n- Dispone di vantaggio ai tiri salvezza effettuati per evitare le trappole o resistere alle trappole.\n- Dispone di resistenza ai danni inferti dalle trappole.\n- Può cercare trappole mentre si muove a passo normale, anziché soltanto a passo lento."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}