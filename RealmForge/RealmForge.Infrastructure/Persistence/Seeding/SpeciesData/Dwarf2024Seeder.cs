using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpeciesData
{
	public static class Dwarf2024Seeder
	{
		//	Deterministic GUID for 2024 SRD Dwarf aggregate
		public static readonly Guid SpeciesId = Guid.Parse("20000000-0000-0000-0000-000000000004");

		public static async Task SeedAsync(RealmForgeDbContext context)
		{
			if (await context.Species.AnyAsync(s => s.Id == SpeciesId))
			{
				return;
			}

			var dwarf = new Species
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
						Name = "Nano",
						Description = "In principio, i nani ebbero origine dalla nuda terra grazie a una divinità della forgia. Conosciuto con vari nomi in altri mondi (Moradin, Reorx e altri), fu proprio quel dio a donare loro l'affinità per la pietra e i metalli, oltre che la propensione per la vita sottoterra. Inoltre, li rese resistenti come montagne, donandogli un'aspettativa di vita di circa 350 anni.\n\nDi bassa statura e spesso dotati di barba, i primi nani scavarono le loro città e roccaforti sui versanti delle montagne e sottoterra. Le loro più antiche leggende narrano di conflitti con mostruosità proprio su quelle vette e nel Sottosuolo, da imponenti giganti a orrori delle profondità. Ispirati da queste storie, i nani di ogni cultura spesso cantano di valorose gesta, in particolare riguardanti i trionfi delle creature più piccole su quelle più grandi.\n\nIn alcuni mondi del multiverso, i primi insediamenti di nani furono costruiti su colline o montagne, ed è il motivo per cui coloro che discendono da questi popoli si fanno chiamare rispettivamente \"nani delle colline\" e \"nani delle montagne\". Tali comunità si trovano nelle ambientazioni di Greyhawk e Dragonlance."
					},
					new SpeciesTranslation
					{
						Language = LanguageCode.En,
						Name = "Dwarf",
						Description = "Dwarves were raised from the earth in the elder days by a deity of the forge. Called by various names on different worlds—Moradin, Reorx, and others—that god gave dwarves an affinity for stone and metal and for living underground. The god also made them resilient like the mountains, with a life span of about 350 years.\n\nSquat and often bearded, the original dwarves carved cities and strongholds into mountainsides and under the earth. Their oldest legends tell of conflicts with the monsters of mountaintops and the Underdark, whether those monsters were towering giants or subterranean horrors. Inspired by those tales, dwarves of any culture often sing of valorous deeds—especially of the little overcoming the mighty.\n\nOn some worlds in the multiverse, the first settlements of dwarves were built in hills or mountains, and the families who trace their ancestry to those settlements call themselves hill dwarves or mountain dwarves, respectively. The Greyhawk and Dragonlance settings have such communities."
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
								Name = "Resilienza nanica",
								Description = "Ha resistenza ai danni da veleno. Dispone di vantaggio sui tiri salvezza eseguiti per evitare o terminare la condizione avvelenato su se stesso."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Dwarven Resilience",
								Description = "You have Resistance to Poison damage. You also have Advantage on saving throws you make to avoid or end the Poisoned condition."
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
								Name = "Robustezza nanica",
								Description = "I punti ferita massimi di un nano aumentano di 1 e aumentano di 1 ogni volta che acquisisce un livello."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Dwarven Toughness",
								Description = "Your Hit Point maximum increases by 1, and it increases by 1 again whenever you gain a level."
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
								Name = "Esperto minatore",
								Description = "Come azione bonus, il personaggio ottiene percezione tellurica con un raggio di 18 metri per 10 minuti. Per poterla utilizzare, deve trovarsi su una superficie di pietra o toccarla. La pietra deve essere naturale o lavorata.\n\nIl personaggio può utilizzare questa azione bonus un numero di volte pari al valore del suo bonus di competenza, recuperando tutti gli utilizzi spesi quando completa un riposo lungo."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Stonecunning",
								Description = "As a Bonus Action, you gain Tremorsense with a range of 60 feet for 10 minutes. You must be on a stone surface or touching a stone surface to use this Tremorsense. The stone can be natural or worked. You can use this Bonus Action a number of times equal to your Proficiency Bonus, and you regain all expended uses when you finish a Long Rest."
							}
						}
					}
				},
				Subspecies = new List<Subspecies>()
			};

			context.Species.Add(dwarf);
			await context.SaveChangesAsync();
		}
	}
}