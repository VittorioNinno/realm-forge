using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpeciesData
{
	public static class Halfling2024Seeder
	{
		//	Deterministic GUID for 2024 SRD Halfling aggregate
		public static readonly Guid SpeciesId = Guid.Parse("20000000-0000-0000-0000-000000000008");

		public static async Task SeedAsync(RealmForgeDbContext context)
		{
			if (await context.Species.AnyAsync(s => s.Id == SpeciesId))
			{
				return;
			}

			var halfling = new Species
			{
				Id = SpeciesId,
				BaseSpeedInFeet = 30,
				CreatureType = CreatureType.Humanoid,
				AllowedSizes = new List<CreatureSize> { CreatureSize.Small },
				Ruleset = RulesetVersion.Dnd5e_2024,
				IsOfficialSRD = true,
				Translations = new List<SpeciesTranslation>
				{
					new SpeciesTranslation
					{
						Language = LanguageCode.It,
						Name = "Halfling",
						Description = "Amati e guidati da dèi che celebrano la vita, la casa e la famiglia, gli halfling tendono a riunirsi in comunità bucoliche che contribuiscono alla propria crescita. Ciò nonostante, molti individui possiedono uno spirito audace che li spinge a partire all'avventura per esplorare un vasto mondo e stringere nuove amicizie. La loro taglia minuta gli consente di mescolarsi tra la folla senza farsi notare e di intrufolarsi in spazi angusti.\n\nChiunque abbia viaggiato con loro ha assistito alla celebre \"fortuna degli halfling\", una forza misteriosa che sembra intervenire ogni volta che si trovano in pericolo di vita. Questo dono divino contribuisce anche a una longevità di circa 150 anni."
					},
					new SpeciesTranslation
					{
						Language = LanguageCode.En,
						Name = "Halfling",
						Description = "Cherished and guided by gods who value life, home, and hearth, halflings gravitate toward bucolic havens where family and community help shape their lives. That said, many halflings possess a brave and adventurous spirit that leads them on journeys of discovery to explore a bigger world and make new friends along the way. Their size helps them pass through crowds unnoticed and slip through tight spaces.\n\nAnyone who has spent time around halflings has likely witnessed the storied \"luck of the halflings\" in action, an unseen force intervening on their behalf in mortal danger. That unusual gift also contributes to their robust life spans of about 150 years."
					}
				},
				Traits = new List<Trait>
				{
					new Trait
					{
						RequiredLevel = 1,
						Ruleset = RulesetVersion.Dnd5e_2024,
						IsOfficialSRD = true,
						Translations = new List<TraitTranslation>
						{
							new TraitTranslation
							{
								Language = LanguageCode.It,
								Name = "Agilità halfling",
								Description = "Può attraversare lo spazio occupato da qualsiasi creatura più grande di lui, ma non può fermarvisi dentro."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Halfling Nimbleness",
								Description = "You can move through the space of any creature that is a size larger than you, but you can't stop in the same space."
							}
						}
					},
					new Trait
					{
						RequiredLevel = 1,
						Ruleset = RulesetVersion.Dnd5e_2024,
						IsOfficialSRD = true,
						Translations = new List<TraitTranslation>
						{
							new TraitTranslation
							{
								Language = LanguageCode.It,
								Name = "Coraggioso",
								Description = "Dispone di vantaggio ai tiri salvezza eseguiti per evitare o terminare la condizione spaventato su se stesso."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Brave",
								Description = "You have Advantage on saving throws you make to avoid or end the Frightened condition."
							}
						}
					},
					new Trait
					{
						RequiredLevel = 1,
						Ruleset = RulesetVersion.Dnd5e_2024,
						IsOfficialSRD = true,
						Translations = new List<TraitTranslation>
						{
							new TraitTranslation
							{
								Language = LanguageCode.It,
								Name = "Fortuna",
								Description = "Quando effettua una prova con d20 (D20 Test) e ottiene 1, può ritirare il dado e deve utilizzare il nuovo risultato."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Luck",
								Description = "When you roll a 1 on the d20 of a D20 Test, you can reroll the die, and you must use the new roll."
							}
						}
					},
					new Trait
					{
						RequiredLevel = 1,
						Ruleset = RulesetVersion.Dnd5e_2024,
						IsOfficialSRD = true,
						Translations = new List<TraitTranslation>
						{
							new TraitTranslation
							{
								Language = LanguageCode.It,
								Name = "Furtività innata",
								Description = "Può effettuare l'azione di nascondersi anche se è oscurato solo da una singola creatura, purché questa sia più grande di lui di almeno una taglia."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Naturally Stealthy",
								Description = "You can take the Hide action even when you are obscured only by a creature that is at least one size larger than you."
							}
						}
					}
				},
				Subspecies = new List<Subspecies>()
			};

			context.Species.Add(halfling);
			await context.SaveChangesAsync();
		}
	}
}