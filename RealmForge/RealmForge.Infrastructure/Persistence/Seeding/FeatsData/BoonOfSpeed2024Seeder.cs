using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Boon of Speed feat (2024 ruleset).
///	</summary>
public static class BoonOfSpeed2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555615");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551651");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551652");

	///	<summary>
	///	Asynchronously seeds the Boon of Speed feat if it does not already exist.
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
					Name = "Boon of Speed",
					Description = "You gain the following benefits:\n- **Ability Score Increase.** Increase one ability score of your choice by 1, to a maximum of 30.\n- **Escape Artist.** As a Bonus Action, you can take the Disengage action, which also ends the Grappled condition on you.\n- **Quickness.** Your Speed increases by 30 feet."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Dono della Velocità",
					Description = "Il personaggio ottiene i seguenti benefici:\n- **Incremento dei Punteggi di Caratteristica.** Il punteggio di una sua caratteristica a scelta aumenta di 1, fino a un massimo di 30.\n- **Artista della Fuga.** Come Azione Bonus, il personaggio può intraprendere l'Azione di Disimpegno, la quale termina anche la condizione Afferrato su di lui.\n- **Rapidità.** La Velocità del personaggio aumenta di 9 metri."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}