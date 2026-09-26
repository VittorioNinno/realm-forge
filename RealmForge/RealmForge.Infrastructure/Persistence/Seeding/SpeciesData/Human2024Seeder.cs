using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpeciesData
{
	public static class Human2024Seeder
	{
		//	Deterministic GUID for 2024 SRD Human aggregate
		public static readonly Guid SpeciesId = Guid.Parse("20000000-0000-0000-0000-000000000001");

		public static async Task SeedAsync(RealmForgeDbContext context)
		{
			if (await context.Species.AnyAsync(s => s.Id == SpeciesId))
			{
				return;
			}

			var human = new Species
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
						Name = "Umano",
						Description = "Sparsi in ogni angolo del multiverso, gli umani sono tanto sfaccettati quanto numerosi e tentano di vivere la loro vita al massimo delle proprie possibilità. Il loro spirito ambizioso e intraprendente è lodato, rispettato e temuto in molti mondi.\n\nGli umani presentano aspetti tanto variegati quanto la popolazione della Terra, e venerano molti dèi diversi. La loro origine è ancora oggetto di dibattito tra gli studiosi, ma pare che uno dei primi raduni di questa specie abbia avuto luogo a Sigil, la città dalla forma geometrica di toro al centro del multiverso e il luogo di nascita della lingua comune. Da qui, gli umani potrebbero essersi diffusi in ogni angolo del multiverso, portando con sé lo spirito cosmopolita della Città delle Porte."
					},
					new SpeciesTranslation
					{
						Language = LanguageCode.En,
						Name = "Human",
						Description = "Found throughout the multiverse, humans are as varied as they are numerous, and they endeavor to achieve as much as they can in the years they are given. Their ambition and resourcefulness are commended, respected, and feared on many worlds.\n\nHumans are as diverse in appearance as the people of Earth, and they have many gods. Scholars dispute the origin of humanity, but one of the earliest known human gatherings is said to have occurred in Sigil, the torus-shaped city at the center of the multiverse and the place where the Common language was born. From there, humans could have spread to every part of the multiverse, bringing the City of Doors' cosmopolitanism with them."
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
								Name = "Intraprendente",
								Description = "Ottiene Ispirazione eroica ogni volta che completa un riposo lungo."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Resourceful",
								Description = "You gain Heroic Inspiration whenever you finish a Long Rest."
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
								Name = "Pluriabilità",
								Description = "Acquisisce competenze in un'abilità a tua scelta."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Skillful",
								Description = "You gain proficiency in one skill of your choice."
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
								Name = "Versatile",
								Description = "Ottiene un talento delle origini a tua scelta (vedi capitolo 5). È consigliato il talento Abile."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Versatile",
								Description = "You gain an Origin feat of your choice (see chapter 5). Skilled is recommended."
							}
						}
					}
				},
				Subspecies = new List<Subspecies>()
			};

			context.Species.Add(human);
			await context.SaveChangesAsync();
		}
	}
}