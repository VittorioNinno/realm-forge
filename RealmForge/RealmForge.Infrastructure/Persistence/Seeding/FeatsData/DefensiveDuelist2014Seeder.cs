using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Defensive Duelist feat (2014 ruleset).
///	</summary>
public static class DefensiveDuelist2014Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555507");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555571");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555572");

	///	<summary>
	///	Asynchronously seeds the Defensive Duelist feat if it does not already exist.
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
					Name = "Defensive Duelist",
					Description = "Prerequisite: Dexterity 13 or higher\nWhen you are wielding a finesse weapon with which you are proficient and another creature hits you with a melee attack, you can use your reaction to add your proficiency bonus to your AC for that attack, potentially causing the attack to miss you."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Duellante Difensivo",
					Description = "Prerequisito: Destrezza 13 o superiore\nQuando il personaggio impugna un'arma accurata in cui è competente e un'altra creatura lo colpisce con un attacco in mischia, egli può usare la sua reazione per aggiungere il suo bonus di competenza alla sua CA per quell'attacco, cosa che potrebbe fare in modo che l'attacco lo manchi."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}