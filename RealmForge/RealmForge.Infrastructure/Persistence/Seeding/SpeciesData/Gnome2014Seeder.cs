using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpeciesData
{
	public static class Gnome2014Seeder
	{
		//	Deterministic GUIDs for 2014 SRD Gnome aggregate
		public static readonly Guid SpeciesId = Guid.Parse("10000000-0000-0000-0000-000000000005");
		public static readonly Guid ForestGnomeSubspeciesId = Guid.Parse("10000000-0000-0000-0005-000000000001");
		public static readonly Guid RockGnomeSubspeciesId = Guid.Parse("10000000-0000-0000-0005-000000000002");

		public static async Task SeedAsync(RealmForgeDbContext context)
		{
			if (await context.Species.AnyAsync(s => s.Id == SpeciesId))
			{
				return;
			}

			var gnome = new Species
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
						Name = "Gnomo",
						Description = "L'energia e l'entusiasmo per la vita traspare in ogni centimetro del minuscolo corpo di uno gnomo. Dal punto di vista di uno gnomo, essere vivi è una cosa meravigliosa ed è giusto spremere ogni goccia di divertimento da una vita che spazia dai tre ai cinque secoli tra invenzioni, esplorazioni e risate."
					},
					new SpeciesTranslation
					{
						Language = LanguageCode.En,
						Name = "Gnome",
						Description = "A gnome's energy and enthusiasm for living shines through every inch of his or her tiny body. As far as gnomes are concerned, being alive is a wonderful thing, and they squeeze every ounce of enjoyment out of their three to five centuries of life exploring, inventing, and laughing."
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
								Description = "Abituato a vivere sottoterra, uno gnomo vede nella penombra e nell'oscurità fino a 18 metri (la penombra è luce intensa e il buio è luce fioca)."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Darkvision (60 ft.)",
								Description = "Accustomed to life underground, you have superior vision in dark and dim conditions up to 60 feet."
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
								Name = "Astuzia Gnomesca",
								Description = "Uno gnomo dispone di vantaggio a tutti i tiri salvezza su Intelligenza, Saggezza e Carisma contro la magia."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Gnome Cunning",
								Description = "You have advantage on all Intelligence, Wisdom, and Charisma saving throws against magic."
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
								Name = "Linguaggi",
								Description = "Uno gnomo sa parlare, leggere e scrivere in Comune e in Gnomesco. Il linguaggio Gnomesco usa l'alfabeto nanico ed è celebre per i trattati tecnici e le enciclopedie."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Languages",
								Description = "You can speak, read, and write Common and Gnomish. The Gnomish language uses the Dwarvish script and is renowned for technical treatises and knowledge catalogs."
							}
						}
					}
				},
				Subspecies = new List<Subspecies>
				{
					new Subspecies
					{
						Id = ForestGnomeSubspeciesId,
						Ruleset = RulesetVersion.Dnd5e_2014,
						IsOfficialSRD = true,
						Translations = new List<SubspeciesTranslation>
						{
							new SubspeciesTranslation
							{
								Language = LanguageCode.It,
								Name = "Gnomo delle Foreste",
								Description = "Uno gnomo delle foreste ha una propensione naturale per l'illusione e gode di una rapidità e furtività innata nei boschi incontaminati."
							},
							new SubspeciesTranslation
							{
								Language = LanguageCode.En,
								Name = "Forest Gnome",
								Description = "As a forest gnome, you have a natural knack for illusion and inherent quickness and stealth in sylvan forests."
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
										Name = "Illusionista Nato",
										Description = "Conosce il trucchetto Illusione Minore (Intelligenza è la caratteristica da incantatore)."
									},
									new TraitTranslation
									{
										Language = LanguageCode.En,
										Name = "Natural Illusionist",
										Description = "You know the minor illusion cantrip (Intelligence is your spellcasting ability for it)."
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
										Name = "Parlare con le Piccole Bestie",
										Description = "Attraverso suoni e gesti può comunicare concetti semplici alle bestie di taglia Piccola o inferiore."
									},
									new TraitTranslation
									{
										Language = LanguageCode.En,
										Name = "Speak with Small Beasts",
										Description = "Through sounds and gestures, you can communicate simple ideas with Small or smaller beasts."
									}
								}
							}
						}
					},
					new Subspecies
					{
						Id = RockGnomeSubspeciesId,
						Ruleset = RulesetVersion.Dnd5e_2014,
						IsOfficialSRD = true,
						Translations = new List<SubspeciesTranslation>
						{
							new SubspeciesTranslation
							{
								Language = LanguageCode.It,
								Name = "Gnomo delle Rocce",
								Description = "Dotato di creatività innata, resistenza superiore e perizia artigianale per congegni tecnologici e riparazioni."
							},
							new SubspeciesTranslation
							{
								Language = LanguageCode.En,
								Name = "Rock Gnome",
								Description = "Endowed with natural inventiveness, superior hardiness, and tinkering expertise for technological clockwork devices."
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
										Name = "Conoscenze dell'Artefice",
										Description = "Aggiunge il doppio del proprio bonus di competenza a ogni prova di Intelligenza (Storia) relativa a oggetti magici, alchemici o congegni tecnologici."
									},
									new TraitTranslation
									{
										Language = LanguageCode.En,
										Name = "Artificer's Lore",
										Description = "Whenever you make an Intelligence (History) check related to magic items, alchemical objects, or technological devices, you add twice your proficiency bonus."
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
										Name = "Inventore",
										Description = "Competenza negli strumenti da inventore. Può spendere 1 ora e 10 mo di materiali per costruire un congegno meccanico Minuscolo (CA 5, 1 pf) a scelta tra: Accendifuoco, Carillon o Giocattolo a Molla (massimo 3 attivi contemporaneamente)."
									},
									new TraitTranslation
									{
										Language = LanguageCode.En,
										Name = "Tinker",
										Description = "Proficiency with artisan's tools (tinker's tools). Using them, you can spend 1 hour and 10 gp of materials to construct a Tiny clockwork device (AC 5, 1 hp): Clockwork Toy, Fire Starter, or Music Box (up to 3 active devices)."
									}
								}
							}
						}
					}
				}
			};

			context.Species.Add(gnome);
			await context.SaveChangesAsync();
		}
	}
}