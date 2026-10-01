using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Two-Weapon Fighting feat (2024 ruleset).
///	</summary>
public static class TwoWeaponFighting2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555605");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551551");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551552");

	///	<summary>
	///	Asynchronously seeds the Two-Weapon Fighting feat if it does not already exist.
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
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Category = FeatCategory.FightingStyle,
			Prerequisite = "Fighting Style Feature",
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Two-Weapon Fighting",
					Description = "When you make an extra attack as a result of using a weapon that has the Light property, you can add your ability modifier to the damage of that attack if you aren't already adding it to the damage."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Combattere con Due Armi",
					Description = "Quando il personaggio effettua un attacco extra sfruttando un'arma che possiede la proprietà Leggera, può aggiungere il suo modificatore di caratteristica al danno di quell'attacco, a patto che non sia già stato aggiunto in altro modo."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}