using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Ritual Caster feat (2024 ruleset).
///	</summary>
public static class RitualCaster2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555583");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551331");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551332");

	///	<summary>
	///	Asynchronously seeds the Ritual Caster feat if it does not already exist.
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
			Prerequisite = "Level 4+; Intelligence, Wisdom, or Charisma 13+",
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Ritual Caster",
					Description = "You gain the following benefits:\n- **Ability Score Increase.** Increase your Intelligence, Wisdom, or Charisma score by 1, to a maximum of 20.\n- **Ritual Spells.** Choose a number of level 1 spells equal to your Proficiency Bonus that have the Ritual tag. You always have those spells prepared, and you can cast them with any spell slots you have. The spells' spellcasting ability is the ability increased by this feat. Whenever your Proficiency Bonus increases thereafter, you can add an additional level 1 spell with the Ritual tag to the spells always prepared with this feature.\n- **Quick Ritual.** With this benefit, you can cast a Ritual spell that you have prepared using its regular casting time rather than the extended time for a Ritual. Doing so doesn't require a spell slot. Once you cast the spell in this way, you can't use this benefit again until you finish a Long Rest."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Incantatore Rituale",
					Description = "Il personaggio ottiene i seguenti benefici:\n- **Incremento dei Punteggi di Caratteristica.** Il suo punteggio di Intelligenza, Saggezza o Carisma aumenta di 1, fino a un massimo di 20.\n- **Incantesimi Rituali.** Il personaggio sceglie un numero di incantesimi di 1° livello con il descrittore Rituale pari al proprio bonus di competenza. Tali incantesimi sono sempre considerati preparati ed è possibile lanciarli con qualunque slot a sua disposizione. La loro caratteristica da incantatore è quella aumentata dal talento. D'ora in avanti, ogni volta che il bonus di competenza del personaggio aumenta, può aggiungere un ulteriore incantesimo di 1° livello con il descrittore Rituale a quelli sempre considerati preparati forniti dal talento.\n- **Rituale Rapido.** Con questo beneficio, il personaggio può lanciare un incantesimo Rituale preparato con un tempo di lancio normale, anziché con quello esteso necessario per un Rituale. A tal proposito non è necessario consumare uno slot incantesimo. Dopo aver lanciato l'incantesimo in questo modo, non può utilizzare questo beneficio di nuovo prima di aver completato un Riposo Lungo."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}