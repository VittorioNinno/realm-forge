using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Boon of the Night Spirit feat (2024 ruleset).
///	</summary>
public static class BoonOfTheNightSpirit2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555617");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551671");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551672");

	///	<summary>
	///	Asynchronously seeds the Boon of the Night Spirit feat if it does not already exist.
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
			Prerequisite = "Level 19+",
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Boon of the Night Spirit",
					Description = "You gain the following benefits:\n- **Ability Score Increase.** Increase one ability score of your choice by 1, to a maximum of 30.\n- **Merge with Shadows.** While within Dim Light or Darkness, you can give yourself the Invisible condition as a Bonus Action. The condition ends on you immediately after you take an action, a Bonus Action, or a Reaction.\n- **Shadowy Form.** While within Dim Light or Darkness, you have Resistance to all damage except Psychic and Radiant."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Dono dello Spirito Notturno",
					Description = "Il personaggio ottiene i seguenti benefici:\n- **Incremento dei Punteggi di Caratteristica.** Il punteggio di una sua caratteristica a scelta aumenta di 1, fino a un massimo di 30.\n- **Fusione con le Ombre.** Finché si trova in un'area di Luce Fioca o Oscurità, il personaggio può ottenere la condizione Invisibile come Azione Bonus. Tale condizione su di lui termina subito dopo aver effettuato un'Azione, un'Azione Bonus o una Reazione.\n- **Forma d'Ombra.** Finché si trova in un'area di Luce Fioca o Oscurità, il personaggio ottiene Resistenza a tutti i danni, tranne ai danni Psichici e Radiosi."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}