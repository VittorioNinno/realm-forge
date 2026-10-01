using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Skulker feat (2014 ruleset).
///	</summary>
public static class Skulker2014Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555538");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555881");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555882");

	///	<summary>
	///	Asynchronously seeds the Skulker feat if it does not already exist.
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
			Prerequisite = "Dexterity 13 or higher",
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Skulker",
					Description = "You are expert at slinking through shadows. You gain the following benefits:\n- You can try to hide when you are lightly obscured from the creature from which you are hiding.\n- When you are hidden from a creature and miss it with a ranged weapon attack, making the attack doesn't reveal your position.\n- Dim light doesn't impose disadvantage on your Wisdom (Perception) checks relying on sight."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Appostato",
					Description = "Il personaggio è abile nello sgusciare tra le ombre e ottiene i benefici seguenti:\n- Può cercare di nascondersi quando si trova in un'area leggermente oscurata rispetto alla creatura da cui si nasconde.\n- Quando è nascosto da una creatura e la manca con un attacco con un'arma a distanza, l'attacco sferrato non rivela la sua posizione.\n- La luce fioca non impone svantaggio alle sue prove di Saggezza (Percezione) basate sulla vista."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}