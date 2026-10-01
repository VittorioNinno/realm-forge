using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Poisoner feat (2024 ruleset).
///	</summary>
public static class Poisoner2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555580");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551301");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551302");

	///	<summary>
	///	Asynchronously seeds the Poisoner feat if it does not already exist.
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
					Name = "Poisoner",
					Description = "You gain the following benefits:\n- **Ability Score Increase.** Increase your Dexterity or Intelligence score by 1, to a maximum of 20.\n- **Potent Poison.** When you make a damage roll that deals Poison damage, it ignores Resistance to Poison damage.\n- **Brew Poison.** You gain proficiency with the Poisoner's Kit. With 1 hour of work using such a kit and expending 50 GP worth of materials, you can create a number of poison doses equal to your Proficiency Bonus. As a Bonus Action, you can apply a poison dose to a weapon or piece of ammunition. Once applied, the poison retains its potency for 1 minute or until you deal damage with the poisoned item, whichever is shorter. When a creature takes damage from the poisoned item, that creature must succeed on a Constitution saving throw (DC 8 plus the modifier of the ability increased by this feat and your Proficiency Bonus) or take 2d8 Poison damage and have the Poisoned condition until the end of your next turn."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Maestria dei Veleni",
					Description = "Il personaggio ottiene i seguenti benefici:\n- **Incremento dei Punteggi di Caratteristica.** Il suo punteggio di Destrezza o Intelligenza aumenta di 1, fino a un massimo di 20.\n- **Veleno Potente.** Quando il personaggio effettua un tiro per i danni che infligge danni da veleno, ignora la resistenza al veleno del bersaglio.\n- **Creare Veleni.** Il personaggio ottiene competenza nelle sostanze da avvelenatore. Impiegando 1 ora di lavoro e utilizzando tali sostanze, nonché 50 mo di materiali, il personaggio può creare un numero di dosi di veleno pari al proprio bonus di competenza. Come Azione Bonus, può applicarne una a un'arma o a una munizione, dopodiché il veleno preserva la sua efficacia per 1 minuto o finché non infligge danni a un bersaglio. Quando una creatura subisce danni da un oggetto avvelenato, deve superare un tiro salvezza su Costituzione (CD 8 più il modificatore della caratteristica aumentata con questo talento e il bonus di competenza), altrimenti subirà 2d8 danni da veleno e sarà Avvelenata fino al termine del turno successivo."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}