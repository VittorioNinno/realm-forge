using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpeciesData
{
	public static class Halfling2014Seeder
	{
		//	Deterministic GUIDs for 2014 SRD Halfling aggregate
		public static readonly Guid SpeciesId = Guid.Parse("10000000-0000-0000-0000-000000000003");
		public static readonly Guid LightfootSubspeciesId = Guid.Parse("10000000-0000-0000-0002-000000000001");
		public static readonly Guid StoutSubspeciesId = Guid.Parse("10000000-0000-0000-0002-000000000002");

		public static async Task SeedAsync(RealmForgeDbContext context)
		{
			if (await context.Species.AnyAsync(s => s.Id == SpeciesId))
			{
				return;
			}

			var halfling = new Species
			{
				Id = SpeciesId,
				BaseSpeedInFeet = 25,
				CreatureType = CreatureType.Humanoid,
				AllowedSizes = new List<CreatureSize> { CreatureSize.Small },
				Ruleset = RulesetVersion.Dnd5e_2014,
				IsOfficialSRD = true,
				Translations = new List<SpeciesTranslation>
				{
					new SpeciesTranslation
					{
						Language = LanguageCode.It,
						Name = "Halfling",
						Description = "La maggior parte degli halfling ambisce soltanto a godersi le comodità di casa: un posto placido e tranquillo dove stabilirsi, lontano dai mostri famelici e dagli scontri tra eserciti, un fuoco scoppiettante, un lauto pasto, un buon vino e una buona conversazione."
					},
					new SpeciesTranslation
					{
						Language = LanguageCode.En,
						Name = "Halfling",
						Description = "The comforts of home are the goals of most halflings' lives: a place to settle in peace and quiet, far from marauding monsters and clashing armies; a blazing fire and a generous meal; fine drink and fine conversation."
					}
				},
				Traits = new List<Trait>
				{
					new Trait
					{
						RequiredLevel = 1,
						Ruleset = RulesetVersion.Dnd5e_2014,
						IsOfficialSRD = true,
						Translations = new List<TraitTranslation>
						{
							new TraitTranslation
							{
								Language = LanguageCode.It,
								Name = "Fortunato",
								Description = "Quando ottiene 1 a un tiro per colpire, a una prova di caratteristica o a un tiro salvezza, un halfling può ripetere il tiro del dado e deve usare il nuovo risultato."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Lucky",
								Description = "When you roll a 1 on an attack roll, ability check, or saving throw, you can reroll the die and must use the new roll."
							}
						}
					},
					new Trait
					{
						RequiredLevel = 1,
						Ruleset = RulesetVersion.Dnd5e_2014,
						IsOfficialSRD = true,
						Translations = new List<TraitTranslation>
						{
							new TraitTranslation
							{
								Language = LanguageCode.It,
								Name = "Coraggioso",
								Description = "Un halfling dispone di vantaggio ai tiri salvezza per non essere spaventato."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Brave",
								Description = "You have advantage on saving throws against being frightened."
							}
						}
					},
					new Trait
					{
						RequiredLevel = 1,
						Ruleset = RulesetVersion.Dnd5e_2014,
						IsOfficialSRD = true,
						Translations = new List<TraitTranslation>
						{
							new TraitTranslation
							{
								Language = LanguageCode.It,
								Name = "Agilità Halfling",
								Description = "Un halfling può muoversi attraverso gli spazi di qualsiasi creatura più grande di lui."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Halfling Nimbleness",
								Description = "You can move through the space of any creature that is of a size larger than yours."
							}
						}
					}
				},
				Subspecies = new List<Subspecies>
				{
					new Subspecies
					{
						Id = LightfootSubspeciesId,
						Ruleset = RulesetVersion.Dnd5e_2014,
						IsOfficialSRD = true,
						Translations = new List<SubspeciesTranslation>
						{
							new SubspeciesTranslation
							{
								Language = LanguageCode.It,
								Name = "Halfling Piedelesto",
								Description = "Un halfling piedelesto è abile nel non farsi notare e può perfino usare le altre persone come copertura. Tende a essere sempre gentile e ad andare d'accordo con gli altri."
							},
							new SubspeciesTranslation
							{
								Language = LanguageCode.En,
								Name = "Lightfoot Halfling",
								Description = "As a lightfoot halfling, you can easily hide from notice, even using other people as cover. You're inclined to be affable and get along well with others."
							}
						},
						Traits = new List<Trait>
						{
							new Trait
							{
								RequiredLevel = 1,
								Ruleset = RulesetVersion.Dnd5e_2014,
								IsOfficialSRD = true,
								Translations = new List<TraitTranslation>
								{
									new TraitTranslation
									{
										Language = LanguageCode.It,
										Name = "Furtività Innata",
										Description = "Un halfling piedelesto può tentare di nascondersi anche se è oscurato solo da una singola creatura, purché questa sia più grande di lui di almeno una taglia."
									},
									new TraitTranslation
									{
										Language = LanguageCode.En,
										Name = "Naturally Stealthy",
										Description = "You can attempt to hide even when you are obscured only by a creature that is at least one size larger than you."
									}
								}
							}
						}
					},
					new Subspecies
					{
						Id = StoutSubspeciesId,
						Ruleset = RulesetVersion.Dnd5e_2014,
						IsOfficialSRD = true,
						Translations = new List<SubspeciesTranslation>
						{
							new SubspeciesTranslation
							{
								Language = LanguageCode.It,
								Name = "Halfling Tozzo",
								Description = "Un halfling tozzo è più robusto della media degli halfling e vanta una certa resistenza al veleno. Stando ad alcuni, gli halfling tozzi avrebbero sangue nanico nelle vene."
							},
							new SubspeciesTranslation
							{
								Language = LanguageCode.En,
								Name = "Stout Halfling",
								Description = "As a stout halfling, you're hardier than average and have some resistance to poison. Some say that stouts have dwarven blood."
							}
						},
						Traits = new List<Trait>
						{
							new Trait
							{
								RequiredLevel = 1,
								Ruleset = RulesetVersion.Dnd5e_2014,
								IsOfficialSRD = true,
								Translations = new List<TraitTranslation>
								{
									new TraitTranslation
									{
										Language = LanguageCode.It,
										Name = "Resilienza dei Tozzi",
										Description = "Un halfling tozzo dispone di vantaggio ai tiri salvezza contro il veleno e di resistenza ai danni da veleno."
									},
									new TraitTranslation
									{
										Language = LanguageCode.En,
										Name = "Stout Resilience",
										Description = "You have advantage on saving throws against poison, and you have resistance against poison damage."
									}
								}
							}
						}
					}
				}
			};

			context.Species.Add(halfling);
			await context.SaveChangesAsync();
		}
	}
}