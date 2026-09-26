using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpeciesData
{
	public static class HalfElf2014Seeder
	{
		//	Deterministic GUID for 2014 SRD Half-Elf aggregate
		public static readonly Guid SpeciesId = Guid.Parse("10000000-0000-0000-0000-000000000006");

		public static async Task SeedAsync(RealmForgeDbContext context)
		{
			if (await context.Species.AnyAsync(s => s.Id == SpeciesId))
			{
				return;
			}

			var halfElf = new Species
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
						Name = "Mezzelfo",
						Description = "I mezzelfi camminano tra due mondi senza mai appartenere fino in fondo a nessuno di essi, e a detta di alcuni uniscono le migliori qualità dei loro genitori elfi e umani: la curiosità, la creatività e l'ambizione degli umani temperate dai sensi raffinati, dall'amore per la natura e dal senso artistico degli elfi."
					},
					new SpeciesTranslation
					{
						Language = LanguageCode.En,
						Name = "Half-Elf",
						Description = "Walking in two worlds but truly belonging to neither, half-elves combine what some say are the best qualities of their elf and human parents: human curiosity, inventiveness, and ambition tempered by the refined senses, love of nature, and artistic tastes of the elves."
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
								Description = "Grazie al suo sangue elfico, un mezzelfo beneficia di una vista superiore nell'oscurità e nelle condizioni di luce fioca fino a 18 metri (luce intensa nella penombra e luce fioca nel buio)."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Darkvision (60 ft.)",
								Description = "Thanks to your elf blood, you have superior vision in dark and dim conditions up to 60 feet (see in dim light as bright light, and darkness as dim light)."
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
								Description = "Un mezzelfo dispone di vantaggio ai tiri salvezza per non essere affascinato e non può essere addormentato tramite la magia."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Fey Ancestry",
								Description = "You have advantage on saving throws against being charmed, and magic can't put you to sleep."
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
								Name = "Versatilità nelle Abilità",
								Description = "Un mezzelfo ha competenza in due abilità a sua scelta."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Skill Versatility",
								Description = "You gain proficiency in two skills of your choice."
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
								Description = "Un mezzelfo può parlare, leggere e scrivere in Comune, in Elfico e in un linguaggio extra a sua scelta."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Languages",
								Description = "You can speak, read, and write Common, Elvish, and one extra language of your choice."
							}
						}
					}
				},
				Subspecies = new List<Subspecies>()
			};

			context.Species.Add(halfElf);
			await context.SaveChangesAsync();
		}
	}
}