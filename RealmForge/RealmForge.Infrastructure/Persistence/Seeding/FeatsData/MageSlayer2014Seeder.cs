using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Mage Slayer feat (2014 ruleset).
///	</summary>
public static class MageSlayer2014Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555522");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555721");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555722");

	///	<summary>
	///	Asynchronously seeds the Mage Slayer feat if it does not already exist.
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
					Name = "Mage Slayer",
					Description = "You have practiced techniques useful in melee combat against spellcasters, gaining the following benefits:\n- When a creature within 5 feet of you casts a spell, you can use your reaction to make a melee weapon attack against that creature.\n- When you damage a creature that is concentrating on a spell, that creature has disadvantage on the saving throw it makes to maintain its concentration.\n- You have advantage on saving throws against spells cast by creatures within 5 feet of you."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Sterminatore di Maghi",
					Description = "Il personaggio ha imparato varie tecniche utili nei combattimenti in mischia contro gli incantatori e ottiene i benefici seguenti:\n- Quando una creatura entro 1,5 metri da lui lancia un incantesimo, egli può usare la sua reazione per effettuare un attacco con un'arma da mischia contro quella creatura.\n- Quando infligge danni su una creatura concentrata su un incantesimo, quella creatura subisce svantaggio al tiro salvezza che effettua per mantenere la concentrazione.\n- Dispone di vantaggio ai tiri salvezza contro gli incantesimi lanciati dalle creature entro 1,5 metri da lui."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}