using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Great Weapon Fighting feat (2024 ruleset).
///	</summary>
public static class GreatWeaponFighting2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555601");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551511");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551512");

	///	<summary>
	///	Asynchronously seeds the Great Weapon Fighting feat if it does not already exist.
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
					Name = "Great Weapon Fighting",
					Description = "When you roll damage for an attack you make with a Melee weapon that you are holding with two hands, you can treat any 1 or 2 on a damage die as a 3. The weapon must have the Two-Handed or Versatile property to gain this benefit."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Combattere con Armi Possenti",
					Description = "Quando il personaggio tira per i danni di un attacco effettuato con un'arma da mischia che impugna a due mani, se il risultato ottenuto su un dado dei danni è 1 o 2, può invece considerarlo come un 3. L'arma deve possedere la proprietà a Due Mani o Versatile per ottenere questo beneficio."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}