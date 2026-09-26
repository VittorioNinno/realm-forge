using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpeciesData
{
	public static class HalfOrc2014Seeder
	{
		//	Deterministic GUID for 2014 SRD Half-Orc aggregate
		public static readonly Guid SpeciesId = Guid.Parse("10000000-0000-0000-0000-000000000007");

		public static async Task SeedAsync(RealmForgeDbContext context)
		{
			if (await context.Species.AnyAsync(s => s.Id == SpeciesId))
			{
				return;
			}

			var halfOrc = new Species
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
						Name = "Mezzorco",
						Description = "I mezzorchi combinano la forza bruta, le zanne prominenti e la furia dei loro progenitori orchi con l'ingegno, l'ambizione e l'autodisciplina ereditate dal sangue umano. Molti cercano gloria guadagnandosi rispetto come fieri guerrieri e indomiti avventurieri."
					},
					new SpeciesTranslation
					{
						Language = LanguageCode.En,
						Name = "Half-Orc",
						Description = "Half-orcs combine the physical might, prominent tusks, and savage fury of their orc heritage with the ambition, cunning, and self-discipline of their human blood. Many venture into the world to prove their worth as fierce warriors and legendary adventurers."
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
								Description = "Grazie al sangue orchesco, beneficia di una vista superiore nell'oscurità e nella luce fioca fino a 18 metri (vede nella penombra come luce intensa e nell'oscurità come luce fioca)."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Darkvision (60 ft.)",
								Description = "Thanks to your orc blood, you have superior vision in dark and dim conditions up to 60 feet (see in dim light as bright light, and darkness as dim light)."
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
								Name = "Minaccioso",
								Description = "Un mezzorco ha competenza nell'abilità Intimidire."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Menacing",
								Description = "You gain proficiency in the Intimidation skill."
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
								Name = "Tenacia Implacabile",
								Description = "Quando un mezzorco scende a 0 punti ferita ma non viene ucciso sul colpo, può decidere di rimanere a 1 punto ferita. Non può più utilizzare questa capacità finché non completa un riposo lungo."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Relentless Endurance",
								Description = "When you are reduced to 0 hit points but not killed outright, you can drop to 1 hit point instead. You can't use this feature again until you finish a long rest."
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
								Name = "Attacchi Selvaggi",
								Description = "Quando un mezzorco mette a segno un colpo critico con un'arma da mischia, può tirare uno dei dadi di danno dell'arma un'ulteriore volta e aggiungerlo ai danni extra del colpo critico."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Savage Attacks",
								Description = "When you score a critical hit with a melee weapon attack, you can roll one of the weapon's damage dice one additional time and add it to the extra damage of the critical hit."
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
								Description = "Un mezzorco sa parlare, leggere e scrivere in Comune e in Orchesco. L'Orchesco è una lingua aspra priva di un alfabeto proprio e scritta con caratteri nanici."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Languages",
								Description = "You can speak, read, and write Common and Orc. Orc is a harsh, grating language that has no script of its own and is written in the Dwarvish script."
							}
						}
					}
				},
				Subspecies = new List<Subspecies>()
			};

			context.Species.Add(halfOrc);
			await context.SaveChangesAsync();
		}
	}
}