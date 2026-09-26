using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpeciesData
{
	public static class Tiefling2014Seeder
	{
		//	Deterministic GUID for 2014 SRD Tiefling aggregate
		public static readonly Guid SpeciesId = Guid.Parse("10000000-0000-0000-0000-000000000008");

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
				AllowedSizes = new List<CreatureSize> { CreatureSize.Medium },
				Ruleset = RulesetVersion.Dnd5e_2014,
				IsOfficialSRD = true,
				Translations = new List<SpeciesTranslation>
				{
					new SpeciesTranslation
					{
						Language = LanguageCode.It,
						Name = "Tiefling",
						Description = "I tiefling derivano da stirpi umane che recano impresso il marchio di un antico patto stipulato generazioni fa con Asmodeus, signore dei Nove Inferi. Grandi corna ricurve, pelle dai toni insoliti o rossastri, coda robusta e occhi privi di pupilla visibile testimoniano la loro eredità infernale."
					},
					new SpeciesTranslation
					{
						Language = LanguageCode.En,
						Name = "Tiefling",
						Description = "Tieflings are derived from human bloodlines touched by an ancient pact made generations ago with Asmodeus, overlord of the Nine Hells. Large curling horns, reddish skin tones, thick tails, and solid-colored eyes bear witness to their enduring infernal heritage."
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
								Description = "Grazie al retaggio infernale, un tiefling beneficia di una vista superiore nell'oscurità e nelle condizioni di luce fioca fino a 18 metri (vede nella penombra come luce intensa e nell'oscurità come luce fioca)."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Darkvision (60 ft.)",
								Description = "Thanks to your infernal heritage, you have superior vision in dark and dim conditions up to 60 feet (see in dim light as bright light, and darkness as dim light)."
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
								Name = "Resistenza Infernale",
								Description = "Un tiefling dispone di resistenza ai danni da fuoco."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Hellish Resistance",
								Description = "You have resistance to fire damage."
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
								Name = "Eredità Infernale",
								Description = "Un tiefling conosce il trucchetto Taumaturgia. Al 3° livello può lanciare l'incantesimo Intimorire Infernale (al 2° livello di slot) una volta per riposo lungo; al 5° livello può lanciare Oscurità una volta per riposo lungo (Carisma è la caratteristica da incantatore)."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Infernal Legacy",
								Description = "You know the thaumaturgy cantrip. At 3rd level, cast hellish rebuke once per long rest as a 2nd-level spell; at 5th level, cast darkness once per long rest (Charisma is your spellcasting ability)."
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
								Description = "Un tiefling sa parlare, leggere e scrivere in Comune e in Infernale."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Languages",
								Description = "You can speak, read, and write Common and Infernal."
							}
						}
					}
				},
				Subspecies = new List<Subspecies>()
			};

			context.Species.Add(tiefling);
			await context.SaveChangesAsync();
		}
	}
}