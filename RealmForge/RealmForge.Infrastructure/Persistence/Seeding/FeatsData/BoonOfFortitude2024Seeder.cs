using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Boon of Fortitude feat (2024 ruleset).
///	</summary>
public static class BoonOfFortitude2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555611");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551611");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551612");

	///	<summary>
	///	Asynchronously seeds the Boon of Fortitude feat if it does not already exist.
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
			Category = FeatCategory.EpicBoon,
			Prerequisite = "Level 19+",
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Boon of Fortitude",
					Description = "You gain the following benefits:\n- **Ability Score Increase.** Increase one ability score of your choice by 1, to a maximum of 30.\n- **Fortified Health.** Your Hit Point maximum increases by 40. In addition, whenever you regain Hit Points, you can regain additional Hit Points equal to your Constitution modifier. Once you've regained these additional Hit Points, you can't do so again until the start of your next turn."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Dono della Tempra",
					Description = "Il personaggio ottiene i seguenti benefici:\n- **Incremento dei Punteggi di Caratteristica.** Il punteggio di una sua caratteristica a scelta aumenta di 1, fino a un massimo di 30.\n- **Salute Rafforzata.** I Punti Ferita massimi del personaggio aumentano di 40. Inoltre, ogni volta che recupera Punti Ferita, può recuperarne una quantità aggiuntiva pari al suo modificatore di Costituzione. Una volta ricevuti questi Punti Ferita extra, il personaggio non può ottenerne altri fino all'inizio del proprio turno successivo."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}