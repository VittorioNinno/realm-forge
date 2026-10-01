using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Telekinetic feat (2024 ruleset).
///	</summary>
public static class Telekinetic2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555593");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551431");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551432");

	///	<summary>
	///	Asynchronously seeds the Telekinetic feat if it does not already exist.
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
					Name = "Telekinetic",
					Description = "You gain the following benefits:\n- **Ability Score Increase.** Increase your Intelligence, Wisdom, or Charisma score by 1, to a maximum of 20.\n- **Minor Telekinesis.** You learn the Mage Hand spell. You can cast it without Verbal or Somatic components, you can make the spectral hand Invisible, and its range and the distance it can be away from you both increase by 30 feet when you cast it. The spell's spellcasting ability is the ability increased by this feat.\n- **Telekinetic Shove.** As a Bonus Action, you can telekinetically shove one creature you can see within 30 feet of yourself. When you do so, the target must succeed on a Strength saving throw (DC 8 plus the ability modifier of the score increased by this feat and your Proficiency Bonus) or be moved 5 feet toward or away from you."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Telecinesi",
					Description = "Il personaggio ottiene i seguenti benefici:\n- **Incremento dei Punteggi di Caratteristica.** Il suo punteggio di Intelligenza, Saggezza o Carisma aumenta di 1, fino a un massimo di 20.\n- **Telecinesi Minore.** Il personaggio conosce l'incantesimo Mano Magica. Può lanciarlo senza componenti verbali o somatiche e rendere invisibile la mano spettrale, incrementando la sua gittata e la distanza alla quale può trovarsi dal personaggio di 9 metri al momento del lancio. La caratteristica da incantatore di questo incantesimo è la caratteristica aumentata dal talento.\n- **Spinta Telecinetica.** Come Azione Bonus, il personaggio può spingere telecineticamente una creatura nel suo campo visivo entro 9 metri di distanza da sé. Il bersaglio deve quindi superare un tiro salvezza su Forza (CD 8 più il modificatore della caratteristica aumentata da questo talento e il bonus di competenza del personaggio) o essere spostato di 1,5 metri verso il personaggio o nella direzione opposta."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}