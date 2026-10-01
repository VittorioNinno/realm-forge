using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Actor feat (2024 ruleset).
///	</summary>
public static class Actor2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555555");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551051");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551052");

	///	<summary>
	///	Asynchronously seeds the Actor feat if it does not already exist.
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
			Prerequisite = "Level 4+, Charisma 13+",
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Actor",
					Description = "You gain the following benefits:\n- **Ability Score Increase.** Increase your Charisma score by 1, to a maximum of 20.\n- **Impersonation.** While you're disguised as a real or fictional person, you have Advantage on Charisma (Deception or Performance) checks to convince others that you are that person.\n- **Mimicry.** You can mimic the sounds of other creatures, including speech. A creature that hears the mimicry must succeed on a Wisdom (Insight) check to determine the effect is faked (DC 8 plus your Charisma modifier and Proficiency Bonus)."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Attore",
					Description = "Il personaggio ottiene i seguenti benefici:\n- **Incremento dei Punteggi di Caratteristica.** Il suo punteggio di Carisma aumenta di 1, fino a un massimo di 20.\n- **Impersonificazione.** Quando il personaggio si finge qualcun altro (che sia reale o fittizio), ha Vantaggio alle prove di Carisma (Inganno o Intrattenere) per convincere gli altri della sua identità.\n- **Imitare.** Il personaggio può imitare i suoni emessi da altre creature, inclusa la parlata. Una creatura che ascolti l'imitazione deve superare una prova di Saggezza (Intuizione) per capirne la natura ingannevole (CD 8 più il modificatore di Carisma e il bonus di competenza)."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}