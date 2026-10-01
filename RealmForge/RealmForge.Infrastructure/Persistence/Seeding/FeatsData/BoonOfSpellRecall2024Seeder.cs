using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Boon of Spell Recall feat (2024 ruleset).
///	</summary>
public static class BoonOfSpellRecall2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555616");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551661");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551662");

	///	<summary>
	///	Asynchronously seeds the Boon of Spell Recall feat if it does not already exist.
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
			Prerequisite = "Level 19+, Spellcasting Feature",
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Boon of Spell Recall",
					Description = "You gain the following benefits:\n- **Ability Score Increase.** Increase your Intelligence, Wisdom, or Charisma score by 1, to a maximum of 30.\n- **Free Casting.** Whenever you cast a spell with a level 1-4 spell slot, roll 1d4. If the number you roll is the same as the slot's level, the slot isn't expended."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Dono del Richiamo degli Incantesimi",
					Description = "Il personaggio ottiene i seguenti benefici:\n- **Incremento dei Punteggi di Caratteristica.** Il suo punteggio di Intelligenza, Saggezza o Carisma aumenta di 1, fino a un massimo di 30.\n- **Lancio Libero.** Quando il personaggio lancia un incantesimo utilizzando uno slot incantesimo di livello da 1 a 4, tira 1d4. Se il risultato ottenuto corrisponde al livello dello slot, quest'ultimo non viene consumato."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}