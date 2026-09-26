using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpeciesData
{
	public static class Tiefling2024Seeder
	{
		//	Deterministic GUIDs for 2024 SRD Tiefling aggregate
		public static readonly Guid SpeciesId = Guid.Parse("20000000-0000-0000-0000-000000000010");
		public static readonly Guid AbyssalSubspeciesId = Guid.Parse("20000000-0000-0000-0010-000000000001");
		public static readonly Guid ChthonicSubspeciesId = Guid.Parse("20000000-0000-0000-0010-000000000002");
		public static readonly Guid InfernalSubspeciesId = Guid.Parse("20000000-0000-0000-0010-000000000003");

		public static async Task SeedAsync(RealmForgeDbContext context)
		{
			if (await context.Species.AnyAsync(s => s.Id == SpeciesId))
			{
				return;
			}

			var tiefling = new Species
			{
				Id = SpeciesId,
				BaseSpeedInFeet = 30,
				CreatureType = CreatureType.Humanoid,
				AllowedSizes = new List<CreatureSize> { CreatureSize.Medium, CreatureSize.Small },
				Ruleset = RulesetVersion.Dnd5e_2024,
				IsOfficialSRD = true,
				Translations = new List<SpeciesTranslation>
				{
					new SpeciesTranslation
					{
						Language = LanguageCode.It,
						Name = "Tiefling",
						Description = "I tiefling sono nati nei Piani Inferiori oppure hanno antenati immondi che provengono da lì. Un tiefling (pronunciato \"ti-fling\") ha un legame di sangue con un diavolo, un demone o un altro immondo. Questo collegamento ai Piani Inferiori rappresenta l’eredità immonda dei tiefling, che comporta una promessa di potere, ma non ha alcun effetto sulla loro moralità.\n\nI tiefling scelgono se abbracciare o rinnegare il proprio retaggio tra la furia caotica dell'Abisso, le oscurità ctonie dell'Ade o la crudele tirannia infernale dei Nove Inferi."
					},
					new SpeciesTranslation
					{
						Language = LanguageCode.En,
						Name = "Tiefling",
						Description = "Tieflings are either born in the Lower Planes or have fiendish ancestors who originated there. A tiefling (pronounced TEE-fling) is linked by blood to a devil, a demon, or some other Fiend. This connection to the Lower Planes is the tiefling's fiendish legacy, which comes with the promise of power yet has no effect on the tiefling's moral outlook.\n\nA tiefling chooses whether to embrace or lament their fiendish legacy, whether drawing upon the chaotic fury of the Abyss, the grim dread of Hades, or the fiery dominion of the Nine Hells."
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
								Description = "Ha scurovisione fino a un raggio di 18 metri."
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
								Name = "Presenza ultraterrena",
								Description = "Conosce il trucchetto taumaturgia. Quando lo lancia sfruttando questo tratto, l'incantesimo utilizza la stessa caratteristica da incantatore scelta per il tratto Retaggio immondo (Intelligenza, Saggezza o Carisma)."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Otherworldly Presence",
								Description = "You know the Thaumaturgy cantrip. When you cast it with this trait, the spell uses the same spellcasting ability you use for your Fiendish Legacy trait (Intelligence, Wisdom, or Charisma)."
							}
						}
					}
				},
				Subspecies = new List<Subspecies>
				{
					new Subspecies
					{
						Id = AbyssalSubspeciesId,
						Ruleset = RulesetVersion.Dnd5e_2024,
						IsOfficialSRD = true,
						Translations = new List<SubspeciesTranslation>
						{
							new SubspeciesTranslation
							{
								Language = LanguageCode.It,
								Name = "Abissale",
								Description = "I tiefling con un retaggio abissale percepiscono il richiamo dell'entropia dell'abisso, del caos di Pandemonium e della disperazione di Carceri. Sono caratterizzati da corna, pelo, zanne e odori particolari. Inoltre, molti di loro hanno sangue demoniaco che gli scorre nelle vene."
							},
							new SubspeciesTranslation
							{
								Language = LanguageCode.En,
								Name = "Abyssal",
								Description = "The entropy of the Abyss, the chaos of Pandemonium, and the despair of Carceri call to tieflings who have the abyssal legacy. Horns, fur, tusks, and peculiar scents are common physical features of such tieflings, most of whom have the blood of demons coursing through their veins."
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
										Name = "Retaggio Abissale (1° Livello)",
										Description = "Ha resistenza ai danni da veleno. Inoltre, conosce il trucchetto spruzzo velenoso (caratteristica: Int, Sag o Car a scelta)."
									},
									new TraitTranslation
									{
										Language = LanguageCode.En,
										Name = "Abyssal Legacy (Level 1)",
										Description = "You have Resistance to Poison damage. You also know the Poison Spray cantrip (spellcasting ability: Int, Wis, or Cha)."
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
										Name = "Magia Abissale: Raggio di Infermità (3° Livello)",
										Description = "Apprendi l'incantesimo Raggio di Infermità. È sempre preparato e puoi lanciarlo una volta senza consumare uno slot incantesimo per riposo lungo, o usando gli slot incantesimo appropriati."
									},
									new TraitTranslation
									{
										Language = LanguageCode.En,
										Name = "Abyssal Magic: Ray of Sickness (Level 3)",
										Description = "You learn the Ray of Sickness spell. It is always prepared, and you can cast it once without a spell slot per Long Rest, or cast it using appropriate spell slots."
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
										Name = "Magia Abissale: Blocca Persone (5° Livello)",
										Description = "Apprendi l'incantesimo Blocca Persone. È sempre preparato e puoi lanciarlo una volta senza consumare uno slot incantesimo per riposo lungo, o usando gli slot incantesimo appropriati."
									},
									new TraitTranslation
									{
										Language = LanguageCode.En,
										Name = "Abyssal Magic: Hold Person (Level 5)",
										Description = "You learn the Hold Person spell. It is always prepared, and you can cast it once without a spell slot per Long Rest, or cast it using appropriate spell slots."
									}
								}
							}
						}
					},
					new Subspecies
					{
						Id = ChthonicSubspeciesId,
						Ruleset = RulesetVersion.Dnd5e_2024,
						IsOfficialSRD = true,
						Translations = new List<SubspeciesTranslation>
						{
							new SubspeciesTranslation
							{
								Language = LanguageCode.It,
								Name = "Ctonio",
								Description = "I tiefling con un retaggio ctonio non sentono solo il richiamo di Carceri, ma anche l’avidità di Gehenna e le tenebre dell’Ade. Alcuni di loro hanno un aspetto cadaverico. Altri, invece, possiedono la bellezza ultraterrena di una succube o le caratteristiche fisiche di una megera notturna, uno yugoloth o qualche altro antenato immondo neutrale malvagio."
							},
							new SubspeciesTranslation
							{
								Language = LanguageCode.En,
								Name = "Chthonic",
								Description = "Tieflings who have the chthonic legacy feel not only the tug of Carceri but also the greed of Gehenna and the gloom of Hades. Some of these tieflings look cadaverous. Others possess the unearthly beauty of a succubus, or they have physical features in common with a night hag, a yugoloth, or some other Neutral Evil fiendish ancestor."
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
										Name = "Retaggio Ctonio (1° Livello)",
										Description = "Possiede resistenza ai danni necrotici. Inoltre, conosce il trucchetto tocco gelido (caratteristica: Int, Sag o Car a scelta)."
									},
									new TraitTranslation
									{
										Language = LanguageCode.En,
										Name = "Chthonic Legacy (Level 1)",
										Description = "You have Resistance to Necrotic damage. You also know the Chill Touch cantrip (spellcasting ability: Int, Wis, or Cha)."
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
										Name = "Magia Ctonia: Vita Falsata (3° Livello)",
										Description = "Apprendi l'incantesimo Vita Falsata. È sempre preparato e puoi lanciarlo una volta senza consumare uno slot incantesimo per riposo lungo, o usando gli slot incantesimo appropriati."
									},
									new TraitTranslation
									{
										Language = LanguageCode.En,
										Name = "Chthonic Magic: False Life (Level 3)",
										Description = "You learn the False Life spell. It is always prepared, and you can cast it once without a spell slot per Long Rest, or cast it using appropriate spell slots."
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
										Name = "Magia Ctonia: Raggio di Affaticamento (5° Livello)",
										Description = "Apprendi l'incantesimo Raggio di Affaticamento. È sempre preparato e puoi lanciarlo una volta senza consumare uno slot incantesimo per riposo lungo, o usando gli slot incantesimo appropriati."
									},
									new TraitTranslation
									{
										Language = LanguageCode.En,
										Name = "Chthonic Magic: Ray of Enfeeblement (Level 5)",
										Description = "You learn the Ray of Enfeeblement spell. It is always prepared, and you can cast it once without a spell slot per Long Rest, or cast it using appropriate spell slots."
									}
								}
							}
						}
					},
					new Subspecies
					{
						Id = InfernalSubspeciesId,
						Ruleset = RulesetVersion.Dnd5e_2024,
						IsOfficialSRD = true,
						Translations = new List<SubspeciesTranslation>
						{
							new SubspeciesTranslation
							{
								Language = LanguageCode.It,
								Name = "Infernale",
								Description = "Il retaggio infernale conferisce ai tiefling non solo un legame con Gehenna, ma anche con i Nove Inferi e le sanguinose battaglie dell’Acheronte. Sono caratterizzati principalmente da corna, aculei, code, occhi ambrati e un vago odore di zolfo o fumo. Molti di loro discendono dai diavoli."
							},
							new SubspeciesTranslation
							{
								Language = LanguageCode.En,
								Name = "Infernal",
								Description = "The infernal legacy connects tieflings not only to Gehenna but also the Nine Hells and the raging battlefields of Acheron. Horns, spines, tails, golden eyes, and a faint odor of sulfur or smoke are common physical features of such tieflings, most of whom trace their ancestry to devils."
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
										Name = "Retaggio Infernale (1° Livello)",
										Description = "Possiede resistenza ai danni da fuoco. Inoltre, conosce il trucchetto dardo di fuoco (caratteristica: Int, Sag o Car a scelta)."
									},
									new TraitTranslation
									{
										Language = LanguageCode.En,
										Name = "Infernal Legacy (Level 1)",
										Description = "You have Resistance to Fire damage. You also know the Fire Bolt cantrip (spellcasting ability: Int, Wis, or Cha)."
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
										Name = "Magia Infernale: Intimorire Infernale (3° Livello)",
										Description = "Apprendi l'incantesimo Intimorire Infernale. È sempre preparato e puoi lanciarlo una volta senza consumare uno slot incantesimo per riposo lungo, o usando gli slot incantesimo appropriati."
									},
									new TraitTranslation
									{
										Language = LanguageCode.En,
										Name = "Infernal Magic: Hellish Rebuke (Level 3)",
										Description = "You learn the Hellish Rebuke spell. It is always prepared, and you can cast it once without a spell slot per Long Rest, or cast it using appropriate spell slots."
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
										Name = "Magia Infernale: Oscurità (5° Livello)",
										Description = "Apprendi l'incantesimo Oscurità. È sempre preparato e puoi lanciarlo una volta senza consumare uno slot incantesimo per riposo lungo, o usando gli slot incantesimo appropriati."
									},
									new TraitTranslation
									{
										Language = LanguageCode.En,
										Name = "Infernal Magic: Darkness (Level 5)",
										Description = "You learn the Darkness spell. It is always prepared, and you can cast it once without a spell slot per Long Rest, or cast it using appropriate spell slots."
									}
								}
							}
						}
					}
				}
			};

			context.Species.Add(tiefling);
			await context.SaveChangesAsync();
		}
	}
}