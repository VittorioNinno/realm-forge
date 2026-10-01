using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Speedy feat (2024 ruleset).
///	</summary>
public static class Speedy2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555591");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551411");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551412");

	///	<summary>
	///	Asynchronously seeds the Speedy feat if it does not already exist.
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
			Prerequisite = "Level 4+, Dexterity or Constitution 13+",
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Speedy",
					Description = "You gain the following benefits:\n- **Ability Score Increase.** Increase your Dexterity or Constitution score by 1, to a maximum of 20.\n- **Speed Increase.** Your Speed increases by 10 feet.\n- **Dash over Difficult Terrain.** When you take the Dash action on your turn, Difficult Terrain doesn't cost you extra movement for the rest of that turn.\n- **Agile Movement.** Opportunity Attacks have Disadvantage against you."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Rapidità",
					Description = "Il personaggio ottiene i seguenti benefici:\n- **Incremento dei Punteggi di Caratteristica.** Il suo punteggio di Destrezza o Costituzione aumenta di 1, fino a un massimo di 20.\n- **Aumento di Velocità.** La velocità del personaggio aumenta di 3 metri.\n- **Scatto sul Terreno Difficile.** Quando il personaggio effettua l'azione di Scatto nel suo turno, il Terreno Difficile non gli costa movimento extra per il resto del turno.\n- **Movimento Agile.** Gli Attacchi di Opportunità effettuati contro il personaggio subiscono Svantaggio."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}