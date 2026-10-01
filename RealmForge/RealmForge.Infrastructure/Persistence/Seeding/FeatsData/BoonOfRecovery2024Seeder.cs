using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Boon of Recovery feat (2024 ruleset).
///	</summary>
public static class BoonOfRecovery2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555613");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551631");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551632");

	///	<summary>
	///	Asynchronously seeds the Boon of Recovery feat if it does not already exist.
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
					Name = "Boon of Recovery",
					Description = "You gain the following benefits:\n- **Ability Score Increase.** Increase one ability score of your choice by 1, to a maximum of 30.\n- **Last Stand.** When you would be reduced to 0 Hit Points, you can drop to 1 Hit Point instead and regain a number of Hit Points equal to half your Hit Point maximum. Once you use this benefit, you can't use it again until you finish a Long Rest.\n- **Recover Vitality.** You have a pool of ten d10s. As a Bonus Action, you can expend dice from the pool, roll those dice, and regain a number of Hit Points equal to the roll's total. You regain all the expended dice when you finish a Long Rest."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Dono del Recupero",
					Description = "Il personaggio ottiene i seguenti benefici:\n- **Incremento dei Punteggi di Caratteristica.** Il punteggio di una sua caratteristica a scelta aumenta di 1, fino a un massimo di 30.\n- **Incrollabile.** Quando il personaggio viene ridotto a 0 Punti Ferita, può invece scendere a 1 Punto Ferita e recuperarne una quantità pari alla metà dei suoi Punti Ferita massimi. Una volta utilizzato questo beneficio, il personaggio non può riutilizzarlo finché non completa un Riposo Lungo.\n- **Recupero di Vitalità.** Il personaggio dispone di una riserva di dieci d10. Come Azione Bonus, può consumare dadi dalla riserva, tirarli e recuperare un numero di Punti Ferita pari al totale del tiro. Il personaggio recupera tutti i dadi spesi quando completa un Riposo Lungo."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}