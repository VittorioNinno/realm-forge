using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Shadow Touched feat (2024 ruleset).
///	</summary>
public static class ShadowTouched2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555585");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551351");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551352");

	///	<summary>
	///	Asynchronously seeds the Shadow Touched feat if it does not already exist.
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
					Name = "Shadow Touched",
					Description = "Your exposure to the Shadowfell's magic grants you the following benefits:\n- **Ability Score Increase.** Increase your Intelligence, Wisdom, or Charisma score by 1, to a maximum of 20.\n- **Shadow Magic.** Choose one level 1 spell from the Illusion or Necromancy school of magic. You always have that spell and the Invisibility spell prepared. You can cast each of these spells without expending a spell slot. Once you cast either spell in this way, you can't cast that spell in this way again until you finish a Long Rest. You can also cast these spells using spell slots you have of the appropriate level. The spells' spellcasting ability is the ability increased by this feat."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Contaminazione Oscura",
					Description = "Grazie alla contaminazione con la magia della Coltre Oscura, il personaggio ottiene i seguenti benefici:\n- **Incremento dei Punteggi di Caratteristica.** Il suo punteggio di Intelligenza, Saggezza o Carisma aumenta di 1, fino a un massimo di 20.\n- **Magia dell'Ombra.** Il personaggio sceglie un incantesimo di 1° livello dalla scuola di magia di Illusione o Necromanzia. L'incantesimo Invisibilità e l'incantesimo scelto sono sempre considerati preparati. Il personaggio può lanciare ciascuno di questi incantesimi senza spendere uno slot incantesimo. Dopo averne lanciato uno senza spendere slot, non può farlo di nuovo in questo modo prima di aver completato un Riposo Lungo. Può anche lanciare questi incantesimi usando gli slot a sua disposizione del livello appropriato. La loro caratteristica da incantatore è quella aumentata dal talento."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}