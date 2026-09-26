using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpeciesData
{
	public static class Orc2024Seeder
	{
		//	Deterministic GUID for 2024 SRD Orc aggregate
		public static readonly Guid SpeciesId = Guid.Parse("20000000-0000-0000-0000-000000000009");

		public static async Task SeedAsync(RealmForgeDbContext context)
		{
			if (await context.Species.AnyAsync(s => s.Id == SpeciesId))
			{
				return;
			}

			var orc = new Species
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
						Name = "Orco",
						Description = "Gli orchi riconducono la propria creazione a Gruumsh, una potente divinità che percorreva gli ampi spazi aperti del Piano Materiale. Gruumsh conferiva ai suoi figli dei doni per aiutarli ad attraversare vaste pianure, immense caverne e mari in tempesta, ma anche per affrontare i mostri al loro interno. Persino quando venerano altri dèi, gli orchi continuano a godere del suo favore e vantano grande resistenza e determinazione, nonché l’abilità di vedere al buio.\n\nIn genere gli orchi sono alti e massicci. Hanno la pelle grigia, con orecchie a punta e canini inferiori sporgenti che ricordano delle zanne. Ai membri più giovani delle specie vengono raccontate le gesta e le fatiche dei propri antenati e, sentendosi ispirati da questi racconti, in molti si chiedono quando riceveranno la chiamata di Gruumsh per dare prova del loro valore, così da guadagnarsi il favore della divinità. Altri, invece, preferiscono non curarsi delle storie del passato, ma di trovare un proprio posto nel mondo."
					},
					new SpeciesTranslation
					{
						Language = LanguageCode.En,
						Name = "Orc",
						Description = "Orcs trace their creation to Gruumsh, a powerful god who roamed the wide open spaces of the Material Plane. Gruumsh equipped his children with gifts to help them wander great plains, vast caverns, and churning seas and to face the monsters that lurk there. Even when they turn their devotion to other gods, orcs retain Gruumsh’s gifts: endurance, determination, and the ability to see in darkness.\n\nOrcs are, on average, tall and broad. They have gray skin, ears that are sharply pointed, and prominent lower canines that resemble small tusks. Orc youths on some worlds are told about their ancestors’ great travels and travails. Inspired by those tales, many of those orcs wonder when Gruumsh will call on them to match the heroic deeds of old and if they will prove worthy of his favor. Other orcs are happy to leave old tales in the past and find their own way."
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
								Name = "Scarica di adrenalina",
								Description = "Può utilizzare l’azione Scatto come azione bonus. Ogni volta che lo fa, ottiene un numero di punti ferita temporanei pari al suo bonus di competenza.\n\nIl personaggio può usare questo tratto un numero di volte pari al valore del suo bonus di competenza e recupera tutti gli utilizzi spesi quando completa un riposo breve o lungo."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Adrenaline Rush",
								Description = "You can take the Dash action as a Bonus Action. When you do so, you gain a number of Temporary Hit Points equal to your Proficiency Bonus. You can use this trait a number of times equal to your Proficiency Bonus, and you regain all expended uses when you finish a Short or Long Rest."
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
								Name = "Scurovisione",
								Description = "Ha scurovisione fino a un raggio di 36 metri."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Darkvision",
								Description = "You have Darkvision with a range of 120 feet."
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
								Name = "Resistenza implacabile",
								Description = "Quando scende a 0 punti ferita ma non viene ucciso sul colpo, può decidere di rimanere a 1 punto ferita. Dopo averlo usato, non può riutilizzare questo tratto prima di aver completato un riposo lungo."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Relentless Endurance",
								Description = "When you are reduced to 0 Hit Points but not killed outright, you can drop to 1 Hit Point instead. Once you use this trait, you can’t do so again until you finish a Long Rest."
							}
						}
					}
				},
				Subspecies = new List<Subspecies>()
			};

			context.Species.Add(orc);
			await context.SaveChangesAsync();
		}
	}
}