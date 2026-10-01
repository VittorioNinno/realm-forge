using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Actor feat (2014 ruleset).
///	</summary>
public static class Actor2014Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555504");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555541");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555542");

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
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Category = FeatCategory.General,
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Actor",
					Description = "Skilled at mimicry and dramatics, you gain the following benefits:\n- Increase your Charisma score by 1, to a maximum of 20.\n- You have advantage on Charisma (Deception) and Charisma (Performance) checks when trying to pass yourself off as a different person.\n- You can mimic the speech of another person or the sounds made by other creatures. You must have heard the person speaking, or heard the creature make the sound, for at least 1 minute. A successful Wisdom (Insight) check contested by your Charisma (Deception) check allows a listener to determine that the effect is faked."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Attore",
					Description = "Il personaggio è abile nella recitazione e nella gestualità e ottiene i benefici seguenti:\n- Il suo punteggio di Carisma aumenta di 1, fino a un massimo di 20.\n- Dispone di vantaggio alle prove di Carisma (Inganno) e Carisma (Intrattenere) quando cerca di spacciarsi per una persona diversa.\n- Può imitare la voce di un'altra persona o i versi di altre creature. Deve avere sentito parlare la persona in questione o avere udito il verso della creatura per almeno 1 minuto. Superando una prova di Saggezza (Intuizione) contrapposta alla prova di Carisma (Inganno) del personaggio, un ascoltatore può capire che l'effetto in questione è falso."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}