using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Crossbow Expert feat (2024 ruleset).
///	</summary>
public static class CrossbowExpert2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555559");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551091");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551092");

	///	<summary>
	///	Asynchronously seeds the Crossbow Expert feat if it does not already exist.
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
			Prerequisite = "Level 4+, Dexterity 13+",
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Crossbow Expert",
					Description = "You gain the following benefits:\n- **Ability Score Increase.** Increase your Dexterity score by 1, to a maximum of 20.\n- **Ignore Loading.** You ignore the Loading property of the Hand Crossbow, Heavy Crossbow, and Light Crossbow (all called crossbows elsewhere in this feat). If you're holding one of them, you can load a piece of ammunition into it even if you lack a free hand.\n- **Firing in Melee.** Being within 5 feet of an enemy doesn't impose Disadvantage on your attack rolls with crossbows.\n- **Dual Wielding.** When you make the extra attack of the Light property, you can add your ability modifier to the damage of the extra attack if that attack is with a crossbow that has the Light property and you aren't already adding that modifier to the damage."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Esperto di Balestre",
					Description = "Il personaggio ottiene i seguenti benefici:\n- **Incremento dei Punteggi di Caratteristica.** Il suo punteggio di Destrezza aumenta di 1, fino a un massimo di 20.\n- **Ignora Ricarica.** Il personaggio ignora la proprietà di ricarica delle balestre a mano, pesanti e leggere (d'ora in avanti chiamate \"balestre\" nella descrizione di questo talento). Se ne impugna una, può effettuare la ricarica anche se non ha una mano libera.\n- **Sparo in Mischia.** Anche se il personaggio si trova a 1,5 metri da un nemico, non ottiene Svantaggio ai tiri per colpire con le balestre.\n- **Combattere a Due Armi.** Quando il personaggio effettua l'attacco extra sfruttando la proprietà Leggera, può aggiungere il suo modificatore di caratteristica ai danni se l'attacco è eseguito con una balestra dotata di tale proprietà e se il modificatore non è già stato aggiunto ai danni."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}