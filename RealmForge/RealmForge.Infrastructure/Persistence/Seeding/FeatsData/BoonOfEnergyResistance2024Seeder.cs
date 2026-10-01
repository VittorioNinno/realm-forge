using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Boon of Energy Resistance feat (2024 ruleset).
///	</summary>
public static class BoonOfEnergyResistance2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555609");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551591");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551592");

	///	<summary>
	///	Asynchronously seeds the Boon of Energy Resistance feat if it does not already exist.
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
					Name = "Boon of Energy Resistance",
					Description = "You gain the following benefits:\n- **Ability Score Increase.** Increase one ability score of your choice by 1, to a maximum of 30.\n- **Energy Resistances.** You gain Resistance to two of the following damage types of your choice: Acid, Cold, Fire, Lightning, Necrotic, Poison, Psychic, Radiant, or Thunder. Whenever you finish a Long Rest, you can change your choices.\n- **Energy Redirection.** When you take damage of one of the types chosen for the Energy Resistances benefit, you can take a Reaction to direct damage of the same type toward another creature you can see within 60 feet of yourself that isn't behind Total Cover. If you do so, that creature must succeed on a Dexterity saving throw (DC 8 plus your Constitution modifier and Proficiency Bonus) or take damage equal to 2d12 plus your Constitution modifier."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Dono della Resistenza all'Energia",
					Description = "Il personaggio ottiene i seguenti benefici:\n- **Incremento dei Punteggi di Caratteristica.** Il punteggio di una sua caratteristica a scelta aumenta di 1, fino a un massimo di 30.\n- **Resistenze Energetiche.** Il personaggio ottiene Resistenza a due dei seguenti tipi di danno a sua scelta: Acido, Freddo, Fulmine, Fuoco, Necrotico, Psichico, Radioso, Tuono o Veleno. Può cambiare le scelte effettuate al termine di ogni Riposo Lungo.\n- **Deviazione dell'Energia.** Quando il personaggio subisce danni di uno dei tipi selezionati per il beneficio Resistenze Energetiche, può utilizzare una Reazione per deviare danni della stessa tipologia verso un'altra creatura che è in grado di vedere entro 18 metri da sé e che non si trovi dietro una Copertura Totale. Se lo fa, la creatura bersaglio deve superare un tiro salvezza su Destrezza (CD 8 più il modificatore di Costituzione e il Bonus di Competenza del personaggio) o subire danni pari a 2d12 più il modificatore di Costituzione del personaggio."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}