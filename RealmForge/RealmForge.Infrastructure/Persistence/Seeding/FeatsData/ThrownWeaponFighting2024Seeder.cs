using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Thrown Weapon Fighting feat (2024 ruleset).
///	</summary>
public static class ThrownWeaponFighting2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555604");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551541");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551542");

	///	<summary>
	///	Asynchronously seeds the Thrown Weapon Fighting feat if it does not already exist.
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
					Name = "Thrown Weapon Fighting",
					Description = "When you hit with a ranged attack roll using a weapon that has the Thrown property, you gain a +2 bonus to the damage roll."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Combattere con Armi da Lancio",
					Description = "Quando il personaggio colpisce con un tiro per colpire a distanza utilizzando un'arma che possiede la proprietà Lancio, ottiene un bonus di +2 al tiro per i danni."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}