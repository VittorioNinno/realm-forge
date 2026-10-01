using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Magic Initiate feat (2014 ruleset).
///	</summary>
public static class MagicInitiate2014Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555523");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555731");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555732");

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
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Category = FeatCategory.General,
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Magic Initiate",
					Description = "Choose a class: bard, cleric, druid, sorcerer, warlock, or wizard. You learn two cantrips of your choice from that class's spell list.\nIn addition, choose one 1st-level spell from that same list. You learn that spell and can cast it at its lowest level. Once you cast it, you must finish a long rest before you can cast it again.\nYour spellcasting ability for these spells depends on the class you chose: Charisma for bard, sorcerer, or warlock; Wisdom for cleric or druid; or Intelligence for wizard."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Iniziato alla Magia",
					Description = "Il personaggio sceglie una classe: bardo, chierico, druido, mago, stregone o warlock. Apprende due trucchetti a sua scelta dalla lista di incantesimi di quella classe.\nSceglie inoltre un incantesimo di 1° livello da apprendere da quella stessa lista. Usando questo talento, può lanciare quell'incantesimo una volta al suo livello più basso e deve completare un riposo lungo prima di poterlo lanciare di nuovo in questo modo.\nLa caratteristica da incantatore del personaggio per questi incantesimi dipende dalla classe scelta: Carisma per il bardo, lo stregone o il warlock; Saggezza per il chierico o il druido; Intelligenza per il mago."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}