using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpeciesData
{
	public static class Elf2014Seeder
	{
		//	Deterministic GUIDs for 2014 SRD Elf aggregate
		public static readonly Guid SpeciesId = Guid.Parse("10000000-0000-0000-0000-000000000002");
		public static readonly Guid HighElfSubspeciesId = Guid.Parse("10000000-0000-0000-0001-000000000001");
		public static readonly Guid WoodElfSubspeciesId = Guid.Parse("10000000-0000-0000-0001-000000000002");
		public static readonly Guid DarkElfSubspeciesId = Guid.Parse("10000000-0000-0000-0001-000000000003");

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
				Ruleset = RulesetVersion.Dnd5e_2014,
				IsOfficialSRD = true,
				Translations = new List<SpeciesTranslation>
				{
					new SpeciesTranslation
					{
						Language = LanguageCode.It,
						Name = "Elfo",
						Description = "Gli elfi sono un popolo magico dalla grazia ultraterrena: pur vivendo nel mondo, non ne fanno parte completamente. Vivono in luoghi di bellezza eterea, al centro di foreste millenarie o all'interno di torri argentate."
					},
					new SpeciesTranslation
					{
						Language = LanguageCode.En,
						Name = "Elf",
						Description = "Elves are a magical people of otherworldly grace, living in the world but not entirely part of it. They live in places of ethereal beauty, in the midst of ancient forests or in silvery spires."
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
								Name = "Scurovisione (18 m)",
								Description = "Abituato a muoversi nella penombra e alla luna, l'elfo vede nell'oscurità e nella luce fioca fino a 18 metri."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Darkvision (60 ft.)",
								Description = "Accustomed to twilit forests and the night sky, you have superior vision in dark and dim conditions up to 60 feet."
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
								Name = "Sensi Acuti",
								Description = "L'elfo ottiene competenza nell'abilità Percezione."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Keen Senses",
								Description = "You have proficiency in the Perception skill."
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
								Name = "Retaggio Fatato",
								Description = "Vantaggio ai tiri salvezza per non essere affascinato e la magia non può addormentarti."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Fey Ancestry",
								Description = "You have advantage on saving throws against being charmed, and magic cannot put you to sleep."
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
								Name = "Trance",
								Description = "Non hai bisogno di dormire; mediti per 4 ore al giorno ottenendo gli stessi benefici di 8 ore di sonno."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Trance",
								Description = "Elves meditate deeply for 4 hours a day instead of sleeping."
							}
						}
					}
				},
				Subspecies = new List<Subspecies>
				{
					new Subspecies
					{
						Id = HighElfSubspeciesId,
						Ruleset = RulesetVersion.Dnd5e_2014,
						IsOfficialSRD = true,
						Translations = new List<SubspeciesTranslation>
						{
							new SubspeciesTranslation
							{
								Language = LanguageCode.It,
								Name = "Elfo Alto",
								Description = "Dotato di una mente brillante e padronanza di alcune forme basilari di magia."
							},
							new SubspeciesTranslation
							{
								Language = LanguageCode.En,
								Name = "High Elf",
								Description = "Possesses a keen mind and mastery of at least the basics of magic."
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
										Name = "Addestramento nelle Armi Elfiche",
										Description = "Competenza nelle spade corte, spade lunghe, archi corti e archi lunghi."
									},
									new TraitTranslation
									{
										Language = LanguageCode.En,
										Name = "Elf Weapon Training",
										Description = "Proficiency with the longsword, shortsword, shortbow, and longbow."
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
										Name = "Trucchetto",
										Description = "Conosce un trucchetto a scelta dalla lista degli incantesimi da mago."
									},
									new TraitTranslation
									{
										Language = LanguageCode.En,
										Name = "Cantrip",
										Description = "You know one cantrip of your choice from the wizard spell list."
									}
								}
							}
						}
					},
					new Subspecies
					{
						Id = WoodElfSubspeciesId,
						BaseSpeedOverrideInFeet = 35,
						Ruleset = RulesetVersion.Dnd5e_2014,
						IsOfficialSRD = true,
						Translations = new List<SubspeciesTranslation>
						{
							new SubspeciesTranslation
							{
								Language = LanguageCode.It,
								Name = "Elfo dei Boschi",
								Description = "Dotato di sensi acuti, profondo intuito e un passo rapido e silenzioso attraverso le foreste natie."
							},
							new SubspeciesTranslation
							{
								Language = LanguageCode.En,
								Name = "Wood Elf",
								Description = "Possesses keen senses and intuition, with fleet feet carrying them quickly and stealthily through native forests."
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
										Name = "Piede Lesto (10,5 m)",
										Description = "La velocità base sul terreno aumenta a 10,5 metri (35 ft)."
									},
									new TraitTranslation
									{
										Language = LanguageCode.En,
										Name = "Fleet of Foot (35 ft.)",
										Description = "Your base walking speed increases to 35 feet."
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
										Name = "Maschera della Selva",
										Description = "Può tentare di nascondersi anche quando è solo leggermente oscurato da fogliame, pioggia battente o neve."
									},
									new TraitTranslation
									{
										Language = LanguageCode.En,
										Name = "Mask of the Wild",
										Description = "You can attempt to hide even when you are only lightly obscured by foliage, heavy rain, or snow."
									}
								}
							}
						}
					},
					new Subspecies
					{
						Id = DarkElfSubspeciesId,
						Ruleset = RulesetVersion.Dnd5e_2014,
						IsOfficialSRD = true,
						Translations = new List<SubspeciesTranslation>
						{
							new SubspeciesTranslation
							{
								Language = LanguageCode.It,
								Name = "Elfo Oscuro (Drow)",
								Description = "Discendenti dagli elfi esiliati nelle viscere dell'Underdark, custodi di una potente magia innata."
							},
							new SubspeciesTranslation
							{
								Language = LanguageCode.En,
								Name = "Dark Elf (Drow)",
								Description = "Descended from elves banished to the Underdark, dwelling in subterranean depths with innate magical powers."
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
										Name = "Scurovisione Superiore (36 m)",
										Description = "La scurovisione arriva fino a 36 metri di raggio (120 ft)."
									},
									new TraitTranslation
									{
										Language = LanguageCode.En,
										Name = "Superior Darkvision (120 ft.)",
										Description = "Your darkvision has a radius of 120 feet."
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
										Name = "Sensibilità alla Luce del精度",
										Description = "Svantaggio ai tiri per colpire e alle prove di Percezione basate sulla vista quando bersaglio o personaggio si trovano in piena luce solare."
									},
									new TraitTranslation
									{
										Language = LanguageCode.En,
										Name = "Sunlight Sensitivity",
										Description = "Disadvantage on attack rolls and Wisdom (Perception) checks that rely on sight when you or the target are in direct sunlight."
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
										Name = "Magia Drow",
										Description = "Conosce Luci Danzanti. Al 3° livello lancia Luminescenza; al 5° livello lancia Oscurità (Carisma è la caratteristica da incantatore)."
									},
									new TraitTranslation
									{
										Language = LanguageCode.En,
										Name = "Drow Magic",
										Description = "You know the Dancing Lights cantrip. At 3rd level, cast Faerie Fire; at 5th level, cast Darkness (Charisma is spellcasting ability)."
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