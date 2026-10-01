using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Ritual Caster feat (2014 ruleset).
///	</summary>
public static class RitualCaster2014Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555532");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555821");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555822");

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
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Category = FeatCategory.General,
			Prerequisite = "Intelligence or Wisdom 13 or higher",
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Ritual Caster",
					Description = "You have learned a number of spells that you can cast as rituals. These spells are written in a ritual book, which you must have in hand while casting one of them.\nWhen you choose this feat, you acquire a ritual book holding two 1st-level spells of your choice. Choose one of the following classes: bard, cleric, druid, sorcerer, warlock, or wizard. You must choose your spells from that class's spell list, and the spells you choose must have the ritual tag. The class you choose also determines your spellcasting ability for these spells: Charisma for bard, sorcerer, or warlock; Wisdom for cleric or druid; or Intelligence for wizard.\nIf you come across a spell in written form, such as a magical spell scroll or a wizard's spellbook, you might be able to add it to your ritual book. The spell must be on the spell list for the class you chose, the spell's level can be no higher than half your level (rounded up), and it must have the ritual tag. The process of copying the spell into your ritual book takes 2 hours per level of the spell, and costs 50 gp per level. The cost represents material components you expend as you experiment with the spell to master it, as well as the fine inks you need to record it."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Incantatore Rituale",
					Description = "Il personaggio ha imparato alcuni incantesimi che può lanciare come rituali. Questi incantesimi sono scritti in un libro dei rituali che il personaggio deve impugnare quando intende lanciarli.\nQuando sceglie questo talento, il personaggio ottiene un libro dei rituali che contiene due incantesimi di 1° livello a sua scelta. Può sceglierli da una delle seguenti classi: bardo, chierico, druido, mago, stregone o warlock. Deve scegliere i suoi incantesimi dalla lista degli incantesimi di quella classe e gli incantesimi che sceglie devono avere il descrittore rituale. La classe scelta determina anche la sua caratteristica da incantatore per quegli incantesimi: Carisma per il bardo, lo stregone o il warlock; Saggezza per il chierico o il druido; Intelligenza per il mago.\nSe il personaggio si imbatte in un incantesimo in forma scritta, come una pergamena magica o il libro degli incantesimi di un mago, può aggiungerlo al suo libro dei rituali. L'incantesimo deve appartenere alla lista degli incantesimi della classe che ha scelto, non può essere di livello superiore alla metà del suo livello del personaggio (arrotondato per eccesso) e deve possedere il descrittore rituale. La procedura per copiare l'incantesimo nel libro dei rituali richiede 2 ore per livello dell'incantesimo e costa 50 mo per livello. Il costo rappresenta le componenti materiali che il personaggio spende mentre sperimenta l'incantesimo per riuscire a padroneggiarlo, nonché gli inchiostri pregiati che gli servono per trascriverlo."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}