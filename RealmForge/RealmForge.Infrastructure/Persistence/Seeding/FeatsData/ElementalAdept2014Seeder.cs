using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Elemental Adept feat (2014 ruleset).
///	</summary>
public static class ElementalAdept2014Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555511");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555611");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555612");

	///	<summary>
	///	Asynchronously seeds the Elemental Adept feat if it does not already exist.
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
			Prerequisite = "The ability to cast at least one spell",
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Elemental Adept",
					Description = "When you gain this feat, choose one of the following damage types: acid, cold, fire, lightning, or thunder.\nSpells you cast ignore resistance to damage of the chosen type. In addition, when you roll damage for a spell you cast that deals damage of that type, you can treat any 1 on a damage die as a 2.\nYou can select this feat multiple times. Each time you do so, you must choose a different damage type."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Adepto Elementale",
					Description = "Quando il personaggio ottiene questo talento, sceglie uno dei tipi di danni seguenti: acido, freddo, fulmine, fuoco o tuono.\nGli incantesimi che lancia ignorano la resistenza ai danni del tipo scelto. Inoltre, quando tira per i danni di un incantesimo da lui lanciato che infligge danni di quel tipo, può considerare ogni 1 ai dadi dei danni come un 2.\nUn personaggio può selezionare questo talento più volte. Ogni volta che lo fa, deve scegliere un tipo di danno diverso."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}