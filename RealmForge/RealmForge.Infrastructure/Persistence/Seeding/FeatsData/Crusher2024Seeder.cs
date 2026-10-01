using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Crusher feat (2024 ruleset).
///	</summary>
public static class Crusher2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555560");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551101");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551102");

	///	<summary>
	///	Asynchronously seeds the Crusher feat if it does not already exist.
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
			Category = FeatCategory.General,
			Prerequisite = "Level 4+",
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Crusher",
					Description = "You gain the following benefits:\n- **Ability Score Increase.** Increase your Strength or Constitution score by 1, to a maximum of 20.\n- **Push.** Once per turn, when you hit a creature with an attack that deals Bludgeoning damage, you can move it 5 feet to an unoccupied space if the target is no more than one size larger than you.\n- **Enhanced Critical.** When you score a Critical Hit that deals Bludgeoning damage to a creature, attack rolls against that creature have Advantage until the start of your next turn."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Martello Vivente",
					Description = "Il personaggio ottiene i seguenti benefici:\n- **Incremento dei Punteggi di Caratteristica.** Il suo punteggio di Forza o Costituzione aumenta di 1, fino a un massimo di 20.\n- **Spinta.** Una volta per turno, quando il personaggio colpisce una creatura con un attacco che infligge danni contundenti, può spostarla di 1,5 metri in uno spazio libero, purché la taglia del bersaglio sia al massimo di una categoria superiore rispetto a quella del personaggio.\n- **Critico Migliorato.** Quando il personaggio mette a segno un colpo critico che infligge danni contundenti a una creatura, dispone di Vantaggio ai tiri per colpire contro quella creatura fino all'inizio del suo turno successivo."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}