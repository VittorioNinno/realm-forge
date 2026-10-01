using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Savage Attacker feat (2014 ruleset).
///	</summary>
public static class SavageAttacker2014Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555533");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555831");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555832");

	///	<summary>
	///	Asynchronously seeds the Savage Attacker feat if it does not already exist.
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
					Name = "Savage Attacker",
					Description = "Once per turn when you roll damage for a melee weapon attack, you can reroll the weapon's damage dice and use either total."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Aggressore Selvaggio",
					Description = "Una volta per turno, quando il personaggio tira per i danni di un attacco con un'arma da mischia, può ripetere il tiro per i danni dell'arma e scegliere quale risultato usare."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}