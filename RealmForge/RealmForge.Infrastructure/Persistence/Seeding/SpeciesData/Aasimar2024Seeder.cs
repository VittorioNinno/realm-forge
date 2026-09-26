using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpeciesData
{
	public static class Aasimar2024Seeder
	{
		//	Deterministic GUID for 2024 SRD Aasimar aggregate
		public static readonly Guid SpeciesId = Guid.Parse("20000000-0000-0000-0000-000000000002");

		public static async Task SeedAsync(RealmForgeDbContext context)
		{
			if (await context.Species.AnyAsync(s => s.Id == SpeciesId))
			{
				return;
			}

			var aasimar = new Species
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
						Name = "Aasimar",
						Description = "Gli aasimar (pronunciato così come si scrive) sono mortali che portano nelle loro anime una scintilla dei Piani Superiori. Che discendano da un essere angelico o siano stati infusi con del potere celestiale, possono sfruttare questa loro caratteristica per portare la luce, guarire il prossimo o scatenare l'ira dei cieli. Gli aasimar possono generarsi all'interno di qualsiasi popolazione di mortali. Assomigliano ai propri genitori, ma possono vivere fino a 160 anni e possiedono dei tratti che lasciano intendere il loro retaggio celestiale, come lentiggini metalliche, occhi luminosi, un'aureola o la pelle dello stesso colore di quella di un angelo (argento, verde opalescente o rosso ramato). Inizialmente, questi tratti sono difficili da notare, ma diventano sempre più ovvi man mano che l'aasimar impara a rivelare la sua piena natura celestiale."
					},
					new SpeciesTranslation
					{
						Language = LanguageCode.En,
						Name = "Aasimar",
						Description = "Aasimar (pronounced AH-sih-mar) are mortals who carry a spark of the Upper Planes within their souls. Whether descended from an angelic being or infused with celestial power, they can fan that spark to bring light, healing, and heavenly fury. Aasimar can arise among any population of mortals. They resemble their parents, but they live for up to 160 years and have features that hint at their celestial heritage, such as metallic freckles, luminous eyes, a halo, or the skin color of an angel (silver, opalescent green, or coppery red). These features start subtle and become obvious when the aasimar learns to reveal their full celestial nature."
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
								Name = "Resistenza celestiale",
								Description = "Possiede resistenza ai danni necrotici e radiosi."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Celestial Resistance",
								Description = "You have Resistance to Necrotic damage and Radiant damage."
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
								Name = "Portatore di luce",
								Description = "Conosce il trucchetto luce. La caratteristica da incantatore per questo trucchetto è Carisma."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Light Bearer",
								Description = "You know the Light cantrip. Charisma is your spellcasting ability for it."
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
								Name = "Mani curative",
								Description = "Con un'azione di Magia, può toccare una creatura e tirare un numero di d4 pari al suo bonus di competenza. La creatura che ha toccato recupera un numero di punti ferita pari al risultato totale del tiro. Dopo aver usato questo tratto, il personaggio non può riutilizzarlo prima di aver completato un riposo lungo."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Healing Hands",
								Description = "As a Magic action, you touch a creature and roll a number of d4s equal to your Proficiency Bonus. The creature regains a number of Hit Points equal to the total rolled. Once you use this trait, you can't use it again until you finish a Long Rest."
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
								Name = "Rivelazione celestiale",
								Description = "Quando raggiunge il 3° livello, può trasformarsi come azione bonus utilizzando una delle opzioni seguenti (scegli l'opzione ogni volta che si trasforma). La trasformazione dura per 1 minuto o finché non la interrompe (nessuna azione richiesta). Una volta effettuata, non può ripeterla finché non completa un riposo lungo.\n\nFino al termine della trasformazione, una volta per ogni suo turno, quando il personaggio infligge danni a un bersaglio con un attacco o un incantesimo, può infliggergli danni extra. L'ammontare di danni extra corrisponde il suo bonus di competenza, con tipologia necrotica per Sudario necrotico o radiosa per Ali celesti e Bagliore interiore.\n\n• Ali celesti: Due ali luminose spuntano temporaneamente dalla schiena del personaggio. Fino al termine della trasformazione, è dotato di una velocità di volo pari alla sua velocità.\n• Bagliore interiore: Una luce bruciante si irradia temporaneamente dagli occhi e dalla bocca del tuo personaggio. Per la durata dell'effetto, emana luce intensa in un'area di 3 metri di raggio e luce fioca per altri 3 metri. Alla fine di ogni turno, tutte le creature entro 3 metri dal personaggio subiscono danni radiosi pari al suo bonus di competenza.\n• Sudario necrotico: Gli occhi del personaggio diventano per un istante vere e proprie pozze di oscurità e ali incapaci di spiccare il volo spuntano temporaneamente dalla sua schiena. Fatta eccezione per i suoi alleati, tutte le creature entro 3 metri dal personaggio devono effettuare un tiro salvezza su Carisma (CD 8 più il modificatore di Carisma e il bonus di competenza), altrimenti saranno spaventate fino al termine del turno successivo."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Celestial Revelation",
								Description = "When you reach character level 3, you can transform as a Bonus Action using one of the options below (choose the option each time you transform). The transformation lasts for 1 minute or until you end it (no action required). Once you transform, you can't do so again until you finish a Long Rest.\n\nOnce on each of your turns before the transformation ends, you can deal extra damage to one target when you deal damage to it with an attack or a spell. The extra damage equals your Proficiency Bonus, and the extra damage's type is either Necrotic for Necrotic Shroud or Radiant for Heavenly Wings and Inner Radiance.\n\n• Heavenly Wings: Two spectral wings sprout from your back temporarily. Until the transformation ends, you have a Fly Speed equal to your Speed.\n• Inner Radiance: Searing light temporarily radiates from your eyes and mouth. For the duration, you shed Bright Light in a 10-foot radius and Dim Light for an additional 10 feet, and at the end of each of your turns, each creature within 10 feet of you takes Radiant damage equal to your Proficiency Bonus.\n• Necrotic Shroud: Your eyes briefly become pools of darkness, and flightless wings sprout from your back temporarily. Creatures other than your allies within 10 feet of you must succeed on a Charisma saving throw (DC 8 plus your Charisma modifier and Proficiency Bonus) or have the Frightened condition until the end of your next turn."
							}
						}
					}
				},
				Subspecies = new List<Subspecies>()
			};

			context.Species.Add(aasimar);
			await context.SaveChangesAsync();
		}
	}
}