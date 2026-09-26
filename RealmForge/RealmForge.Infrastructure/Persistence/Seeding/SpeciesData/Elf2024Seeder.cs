using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpeciesData
{
	public static class Elf2024Seeder
	{
		//	Deterministic GUIDs for 2024 SRD Elf aggregate
		public static readonly Guid SpeciesId = Guid.Parse("20000000-0000-0000-0000-000000000005");
		public static readonly Guid DrowSubspeciesId = Guid.Parse("20000000-0000-0000-0005-000000000001");
		public static readonly Guid HighElfSubspeciesId = Guid.Parse("20000000-0000-0000-0005-000000000002");
		public static readonly Guid WoodElfSubspeciesId = Guid.Parse("20000000-0000-0000-0005-000000000003");

		public static async Task SeedAsync(RealmForgeDbContext context)
		{
			if (await context.Species.AnyAsync(s => s.Id == SpeciesId))
			{
				return;
			}

			var elf = new Species
			{
				Id = SpeciesId,
				BaseSpeedInFeet = 30,
				CreatureType = CreatureType.Humanoid,
				AllowedSizes = new List<CreatureSize> { CreatureSize.Medium },
				Ruleset = RulesetVersion.Dnd5e_2024,
				IsOfficialSRD = true,
				Translations = new List<SpeciesTranslation>
				{
					new SpeciesTranslation
					{
						Language = LanguageCode.It,
						Name = "Elfo",
						Description = "Creati dal dio Corellon, i primi elfi erano in grado di cambiare la propria forma a piacimento. Persero questa capacità quando Corellon li maledisse per aver cospirato con la divinità Lolth, che tentò invano di usurparne il dominio. Quando Lolth venne gettata nell'abisso, molti elfi la rinnegarono e ottennero il perdono di Corellon. Tuttavia, ciò che il loro dio gli aveva sottratto era ormai andato perduto per sempre.\n\nOrmai privi della loro abilità mutaforma, gli elfi si ritirarono nella Selva Fatata, dove il loro dolore si intensificò per via dell'influenza di quel piano. Nel tempo, spinti dalla curiosità, furono in molti ad avventurarsi in altri piani di esistenza, inclusi i mondi del Piano Materiale.\n\nGli elfi hanno orecchie a punta e sono privi di peli facciali o corporei. Vivono per circa 750 anni e quando hanno bisogno di riposarsi vanno in trance anziché dormire. Così facendo, assumono uno stato che gli consente di rimanere consapevoli dell'ambiente circostante, mentre si lasciano trasportare dai propri ricordi e le proprie riflessioni.\n\nQuando gli elfi vivono in un luogo per più di un millennio, l'ambiente che li circonda finisce per trasformarli leggermente, donandogli determinati tipi di magia. Alcuni esempi di questo fenomeno sono i drow, gli elfi alti e gli elfi dei boschi."
					},
					new SpeciesTranslation
					{
						Language = LanguageCode.En,
						Name = "Elf",
						Description = "Created by the god Corellon, the first elves could change their forms at will. They lost this ability when Corellon cursed them for plotting with the deity Lolth, who tried and failed to usurp Corellon's dominion. When Lolth was cast into the Abyss, most elves renounced her and earned Corellon's forgiveness, but that which Corellon had taken from them was lost forever.\n\nNo longer able to shape-shift at will, the elves retreated to the Feywild, where their sorrow was deepened by that plane's influence. Over time, curiosity led many of them to explore other planes of existence, including worlds in the Material Plane.\n\nElves have pointed ears and lack facial and body hair. They live for around 750 years, and they don't sleep but instead enter a trance when they need to rest. In that state, they remain aware of their surroundings while immersing themselves in memories and meditations.\n\nAn environment subtly transforms elves after they inhabit it for a millennium or more, and it grants them certain kinds of magic. Drow, high elves, and wood elves are examples of elves who have been transformed thus."
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
								Name = "Scurovisione",
								Description = "Il personaggio ha scurovisione fino a un raggio di 18 metri."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Darkvision",
								Description = "You have Darkvision with a range of 60 feet."
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
								Name = "Retaggio fatato",
								Description = "Dispone di vantaggio ai tiri salvezza eseguiti per evitare o terminare la condizione affascinato su se stesso."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Fey Ancestry",
								Description = "You have Advantage on saving throws you make to avoid or end the Charmed condition."
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
								Name = "Sensi acuti",
								Description = "Ha competenza nelle abilità Intuizione, Percezione o Sopravvivenza."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Keen Senses",
								Description = "You have proficiency in the Insight, Perception, or Survival skill."
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
								Name = "Trance",
								Description = "Non ha bisogno di dormire e la magia non può farlo addormentare. Può completare un riposo lungo in 4 ore rimanendo in uno stato di trance meditativa, durante il quale resta cosciente."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Trance",
								Description = "You don't need to sleep, and magic can't put you to sleep. You can finish a Long Rest in 4 hours if you spend those hours in a trancelike meditation, during which you retain consciousness."
							}
						}
					}
				},
				Subspecies = new List<Subspecies>
				{
					new Subspecies
					{
						Id = DrowSubspeciesId,
						Ruleset = RulesetVersion.Dnd5e_2024,
						IsOfficialSRD = true,
						Translations = new List<SubspeciesTranslation>
						{
							new SubspeciesTranslation
							{
								Language = LanguageCode.It,
								Name = "Drow",
								Description = "In genere, i drow dimorano nel Sottosuolo, un ambiente che ha plasmato i loro tratti. Alcuni individui e società appartenenti a questa razza lo evitano del tutto, eppure sono pervasi dalla sua magia. Per esempio, nell'ambientazione di Eberron, i drow popolano le foreste pluviali e le rovine ciclopiche sul continente di Xen'drik."
							},
							new SubspeciesTranslation
							{
								Language = LanguageCode.En,
								Name = "Drow",
								Description = "Drow typically dwell in the Underdark and have been shaped by it. Some drow individuals and societies avoid the Underdark altogether yet carry its magic. In the Eberron setting, for example, drow dwell in rainforests and cyclopean ruins on the continent of Xen'drik."
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
										Name = "Lignaggio Drow (1° Livello)",
										Description = "La portata di scurovisione aumenta fino a 36 metri. Inoltre, il personaggio conosce il trucchetto luci danzanti."
									},
									new TraitTranslation
									{
										Language = LanguageCode.En,
										Name = "Drow Lineage (Level 1)",
										Description = "The range of your Darkvision increases to 120 feet. You also know the Dancing Lights cantrip."
									}
								}
							},
							new Trait
							{
								RequiredLevel = 3,
								Ruleset = RulesetVersion.Dnd5e_2024,
								IsOfficialSRD = true,
								Translations = new List<TraitTranslation>
								{
									new TraitTranslation
									{
										Language = LanguageCode.It,
										Name = "Magia Drow: Luminescenza (3° Livello)",
										Description = "Apprendi l'incantesimo Luminescenza. È sempre considerato preparato e puoi lanciarlo una volta senza consumare uno slot incantesimo per riposo lungo, o usando gli slot incantesimo appropriati (caratteristica: Int, Sag o Car a scelta)."
									},
									new TraitTranslation
									{
										Language = LanguageCode.En,
										Name = "Drow Magic: Faerie Fire (Level 3)",
										Description = "You learn the Faerie Fire spell. It is always prepared, and you can cast it once without a spell slot per Long Rest, or cast it using appropriate spell slots (spellcasting ability: Int, Wis, or Cha)."
									}
								}
							},
							new Trait
							{
								RequiredLevel = 5,
								Ruleset = RulesetVersion.Dnd5e_2024,
								IsOfficialSRD = true,
								Translations = new List<TraitTranslation>
								{
									new TraitTranslation
									{
										Language = LanguageCode.It,
										Name = "Magia Drow: Oscurità (5° Livello)",
										Description = "Apprendi l'incantesimo Oscurità. È sempre considerato preparato e puoi lanciarlo una volta senza consumare uno slot incantesimo per riposo lungo, o usando gli slot incantesimo appropriati (caratteristica: Int, Sag o Car a scelta)."
									},
									new TraitTranslation
									{
										Language = LanguageCode.En,
										Name = "Drow Magic: Darkness (Level 5)",
										Description = "You learn the Darkness spell. It is always prepared, and you can cast it once without a spell slot per Long Rest, or cast it using appropriate spell slots (spellcasting ability: Int, Wis, or Cha)."
									}
								}
							}
						}
					},
					new Subspecies
					{
						Id = HighElfSubspeciesId,
						Ruleset = RulesetVersion.Dnd5e_2024,
						IsOfficialSRD = true,
						Translations = new List<SubspeciesTranslation>
						{
							new SubspeciesTranslation
							{
								Language = LanguageCode.It,
								Name = "Elfo Alto",
								Description = "Gli elfi alti sono stati infusi con la magia degli attraversamenti tra la Selva Fatata e il Piano Materiale. In alcuni mondi, questa specie si è data altri nomi. Per esempio, si chiamano elfi del sole o elfi della luna nell'ambientazione dei Forgotten Realms, Silvanesti e Qualinesti in Dragonlance e Aereni in Eberron."
							},
							new SubspeciesTranslation
							{
								Language = LanguageCode.En,
								Name = "High Elf",
								Description = "High elves have been infused with the magic of crossings between the Feywild and the Material Plane. On some worlds, high elves refer to themselves by other names. For example, they call themselves sun or moon elves in the Forgotten Realms setting, Silvanesti and Qualinesti in the Dragonlance setting, and Aereni in the Eberron setting."
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
										Name = "Lignaggio dell'Elfo Alto (1° Livello)",
										Description = "Il personaggio impara il trucchetto prestidigitazione. Ogni volta che completa un riposo lungo, può sostituirlo con un altro trucchetto dalla lista degli incantesimi del mago."
									},
									new TraitTranslation
									{
										Language = LanguageCode.En,
										Name = "High Elf Lineage (Level 1)",
										Description = "You know the Prestidigitation cantrip. Whenever you finish a Long Rest, you can replace that cantrip with a different cantrip from the Wizard spell list."
									}
								}
							},
							new Trait
							{
								RequiredLevel = 3,
								Ruleset = RulesetVersion.Dnd5e_2024,
								IsOfficialSRD = true,
								Translations = new List<TraitTranslation>
								{
									new TraitTranslation
									{
										Language = LanguageCode.It,
										Name = "Magia dell'Elfo Alto: Individuazione del Magico (3° Livello)",
										Description = "Apprendi l'incantesimo Individuazione del Magico. È sempre considerato preparato e puoi lanciarlo una volta senza consumare uno slot incantesimo per riposo lungo, o usando gli slot incantesimo appropriati (caratteristica: Int, Sag o Car a scelta)."
									},
									new TraitTranslation
									{
										Language = LanguageCode.En,
										Name = "High Elf Magic: Detect Magic (Level 3)",
										Description = "You learn the Detect Magic spell. It is always prepared, and you can cast it once without a spell slot per Long Rest, or cast it using appropriate spell slots (spellcasting ability: Int, Wis, or Cha)."
									}
								}
							},
							new Trait
							{
								RequiredLevel = 5,
								Ruleset = RulesetVersion.Dnd5e_2024,
								IsOfficialSRD = true,
								Translations = new List<TraitTranslation>
								{
									new TraitTranslation
									{
										Language = LanguageCode.It,
										Name = "Magia dell'Elfo Alto: Passo Velato (5° Livello)",
										Description = "Apprendi l'incantesimo Passo Velato. È sempre considerato preparato e puoi lanciarlo una volta senza consumare uno slot incantesimo per riposo lungo, o usando gli slot incantesimo appropriati (caratteristica: Int, Sag o Car a scelta)."
									},
									new TraitTranslation
									{
										Language = LanguageCode.En,
										Name = "High Elf Magic: Misty Step (Level 5)",
										Description = "You learn the Misty Step spell. It is always prepared, and you can cast it once without a spell slot per Long Rest, or cast it using appropriate spell slots (spellcasting ability: Int, Wis, or Cha)."
									}
								}
							}
						}
					},
					new Subspecies
					{
						Id = WoodElfSubspeciesId,
						BaseSpeedOverrideInFeet = 35,
						Ruleset = RulesetVersion.Dnd5e_2024,
						IsOfficialSRD = true,
						Translations = new List<SubspeciesTranslation>
						{
							new SubspeciesTranslation
							{
								Language = LanguageCode.It,
								Name = "Elfo dei Boschi",
								Description = "Gli elfi dei boschi incarnano la magia delle foreste primordiali. Vengono chiamati anche in molti altri modi, come elfi selvaggi, elfi verdi ed elfi delle foreste. I Grugach sono elfi dei boschi solitari dell'ambiente di Greyhawk, mentre i Kagonesti e i Tairnadal appartengono rispettivamente alle ambientazioni di Dragonlance ed Eberron."
							},
							new SubspeciesTranslation
							{
								Language = LanguageCode.En,
								Name = "Wood Elf",
								Description = "Wood elves carry the magic of primeval forests within themselves. They are known by many other names, including wild elves, green elves, and forest elves. Grugach are reclusive wood elves of the Greyhawk setting, while the Kagonesti and the Tairnadal are wood elves of the Dragonlance and Eberron settings, respectively."
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
										Name = "Lignaggio dell'Elfo dei Boschi (1° Livello)",
										Description = "La velocità del personaggio aumenta a 10,5 metri (35 ft). Inoltre, conosce il trucchetto artificio druidico."
									},
									new TraitTranslation
									{
										Language = LanguageCode.En,
										Name = "Wood Elf Lineage (Level 1)",
										Description = "Your Speed increases to 35 feet. You also know the Druidcraft cantrip."
									}
								}
							},
							new Trait
							{
								RequiredLevel = 3,
								Ruleset = RulesetVersion.Dnd5e_2024,
								IsOfficialSRD = true,
								Translations = new List<TraitTranslation>
								{
									new TraitTranslation
									{
										Language = LanguageCode.It,
										Name = "Magia dell'Elfo dei Boschi: Passo Veloce (3° Livello)",
										Description = "Apprendi l'incantesimo Passo Veloce (Longstrider). È sempre considerato preparato e puoi lanciarlo una volta senza consumare uno slot incantesimo per riposo lungo, o usando gli slot incantesimo appropriati (caratteristica: Int, Sag o Car a scelta)."
									},
									new TraitTranslation
									{
										Language = LanguageCode.En,
										Name = "Wood Elf Magic: Longstrider (Level 3)",
										Description = "You learn the Longstrider spell. It is always prepared, and you can cast it once without a spell slot per Long Rest, or cast it using appropriate spell slots (spellcasting ability: Int, Wis, or Cha)."
									}
								}
							},
							new Trait
							{
								RequiredLevel = 5,
								Ruleset = RulesetVersion.Dnd5e_2024,
								IsOfficialSRD = true,
								Translations = new List<TraitTranslation>
								{
									new TraitTranslation
									{
										Language = LanguageCode.It,
										Name = "Magia dell'Elfo dei Boschi: Passare Senza Tracce (5° Livello)",
										Description = "Apprendi l'incantesimo Passare Senza Tracce (Pass without Trace). È sempre considerato preparato e puoi lanciarlo una volta senza consumare uno slot incantesimo per riposo lungo, o usando gli slot incantesimo appropriati (caratteristica: Int, Sag o Car a scelta)."
									},
									new TraitTranslation
									{
										Language = LanguageCode.En,
										Name = "Wood Elf Magic: Pass without Trace (Level 5)",
										Description = "You learn the Pass without Trace spell. It is always prepared, and you can cast it once without a spell slot per Long Rest, or cast it using appropriate spell slots (spellcasting ability: Int, Wis, or Cha)."
									}
								}
							}
						}
					}
				}
			};

			context.Species.Add(elf);
			await context.SaveChangesAsync();
		}
	}
}