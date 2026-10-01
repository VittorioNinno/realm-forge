using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Boon of Combat Prowess feat (2024 ruleset).
///	</summary>
public static class BoonOfCombatProwess2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555607");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551571");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551572");

	///	<summary>
	///	Asynchronously seeds the Boon of Combat Prowess feat if it does not already exist.
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
					Name = "Boon of Combat Prowess",
					Description = "You gain the following benefits:\n- **Ability Score Increase.** Increase one ability score of your choice by 1, to a maximum of 30.\n- **Peerless Aim.** When you miss with an attack roll, you can hit instead. Once you use this benefit, you can't use it again until the start of your next turn."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Dono delle Abilità di Combattimento",
					Description = "Il personaggio ottiene i seguenti benefici:\n- **Incremento dei Punteggi di Caratteristica.** Il punteggio di una sua caratteristica a scelta aumenta di 1, fino a un massimo di 30.\n- **Mira Impareggiabile.** Quando il tiro per colpire del personaggio non va a segno, può decidere di colpire comunque il bersaglio. Una volta sfruttato questo beneficio, il personaggio non può riutilizzarlo fino all'inizio del proprio turno successivo."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}