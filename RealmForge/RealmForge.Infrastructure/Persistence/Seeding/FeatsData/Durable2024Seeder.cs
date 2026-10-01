using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Durable feat (2024 ruleset).
///	</summary>
public static class Durable2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555563");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551131");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551132");

	///	<summary>
	///	Asynchronously seeds the Durable feat if it does not already exist.
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
					Name = "Durable",
					Description = "You gain the following benefits:\n- **Ability Score Increase.** Increase your Constitution score by 1, to a maximum of 20.\n- **Defy Death.** You have Advantage on Death Saving Throws.\n- **Speedy Recovery.** As a Bonus Action, you can expend one of your Hit Point Dice, roll the die, and regain a number of Hit Points equal to the roll."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Tenace",
					Description = "Il personaggio ottiene i seguenti benefici:\n- **Incremento dei Punteggi di Caratteristica.** Il suo punteggio di Costituzione aumenta di 1, fino a un massimo di 20.\n- **Sfuggire alla Morte.** Il personaggio dispone di Vantaggio ai Tiri Salvezza contro Morte.\n- **Recupero Rapido.** Come Azione Bonus, il personaggio può utilizzare uno dei suoi Dadi Vita per eseguire un tiro e recuperare un numero di punti ferita corrispondente al risultato ottenuto."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}