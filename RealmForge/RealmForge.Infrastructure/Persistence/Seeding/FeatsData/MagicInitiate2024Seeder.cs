using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Magic Initiate feat (2024 ruleset).
///	</summary>
public static class MagicInitiate2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555548");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555981");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555982");

	///	<summary>
	///	Asynchronously seeds the Magic Initiate feat if it does not already exist.
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
			Category = FeatCategory.Origin,
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Magic Initiate",
					Description = "You gain the following benefits:\n- **Two Cantrips.** You learn two cantrips of your choice from the Cleric, Druid, or Wizard spell list. Intelligence, Wisdom, or Charisma is your spellcasting ability for this feat's spells (choose when you select this feat).\n- **Level 1 Spell.** Choose a level 1 spell from the same list you selected for this feat's cantrips. You always have that spell prepared. You can cast it once without a spell slot, and you regain the ability to cast it in that way when you finish a Long Rest. You can also cast the spell using any spell slots you have.\n- **Spell Change.** Whenever you gain a new level, you can replace one of the spells you chose for this feat with a different spell of the same level from the chosen spell list.\n- **Repeatable.** You can take this feat more than once, but you must choose a different spell list each time."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Iniziato alla Magia",
					Description = "Il personaggio ottiene i seguenti benefici:\n- **Due Trucchetti.** Il personaggio prende due trucchetti a scelta tratti dalla lista degli incantesimi da chierico, druido o mago. La caratteristica da incantatore per gli incantesimi da questo talento può essere Intelligenza, Saggezza o Carisma (scegli la caratteristica quando ottieni questo talento).\n- **Incantesimo di 1° Livello.** Scegli un incantesimo di 1° livello dalla stessa classe da cui hai selezionato i trucchetti forniti da questo talento. Tale incantesimo è sempre considerato come preparato. Il personaggio può lanciarlo una volta senza consumare uno slot incantesimo e ne recupera l'utilizzo in questo modo dopo aver completato un Riposo Lungo. Può anche lanciare l'incantesimo usando uno qualsiasi degli slot incantesimo a sua disposizione.\n- **Cambio Incantesimo.** Quando il personaggio ottiene un nuovo livello, può sostituire uno degli incantesimi scelti per questo talento con un altro dello stesso livello della lista prescelta.\n- **Ripetibile.** Questo talento è ottenibile più di una volta, ma devi scegliere una lista degli incantesimi diversa a ogni selezione."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}