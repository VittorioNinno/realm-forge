using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpeciesData
{
	public static class Dragonborn2024Seeder
	{
		//	Deterministic GUID for 2024 SRD Dragonborn aggregate
		public static readonly Guid SpeciesId = Guid.Parse("20000000-0000-0000-0000-000000000003");

		private record AncestorConfig(
			Guid Id,
			string NameIt,
			string NameEn,
			string DamageTypeIt,
			string DamageTypeEn
		);

		private static readonly AncestorConfig[] Ancestors = new[]
		{
			new AncestorConfig(Guid.Parse("20000000-0000-0000-0004-000000000001"), "Drago Nero", "Black Dragon", "Acido", "Acid"),
			new AncestorConfig(Guid.Parse("20000000-0000-0000-0004-000000000002"), "Drago Blu", "Blue Dragon", "Fulmine", "Lightning"),
			new AncestorConfig(Guid.Parse("20000000-0000-0000-0004-000000000003"), "Drago d'Ottone", "Brass Dragon", "Fuoco", "Fire"),
			new AncestorConfig(Guid.Parse("20000000-0000-0000-0004-000000000004"), "Drago di Bronzo", "Bronze Dragon", "Fulmine", "Lightning"),
			new AncestorConfig(Guid.Parse("20000000-0000-0000-0004-000000000005"), "Drago di Rame", "Copper Dragon", "Acido", "Acid"),
			new AncestorConfig(Guid.Parse("20000000-0000-0000-0004-000000000006"), "Drago d'Oro", "Gold Dragon", "Fuoco", "Fire"),
			new AncestorConfig(Guid.Parse("20000000-0000-0000-0004-000000000007"), "Drago Verde", "Green Dragon", "Veleno", "Poison"),
			new AncestorConfig(Guid.Parse("20000000-0000-0000-0004-000000000008"), "Drago Rosso", "Red Dragon", "Fuoco", "Fire"),
			new AncestorConfig(Guid.Parse("20000000-0000-0000-0004-000000000009"), "Drago d'Argento", "Silver Dragon", "Freddo", "Cold"),
			new AncestorConfig(Guid.Parse("20000000-0000-0000-0004-000000000010"), "Drago Bianco", "White Dragon", "Freddo", "Cold")
		};

		public static async Task SeedAsync(RealmForgeDbContext context)
		{
			if (await context.Species.AnyAsync(s => s.Id == SpeciesId))
			{
				return;
			}

			var dragonborn = new Species
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
						Name = "Dragonide",
						Description = "Gli antenati dei dragonidi hanno avuto origine dalle uova di draghi cromatici e metallici. Secondo una leggenda, queste uova furono benedette dagli dei draconici Bahamut e Tiamat, che desideravano popolare il multiverso con degli esseri creati a propria immagine e somiglianza. Un'altra, invece, sostiene che i draghi abbiano dato vita a questa specie senza la benedizione degli dei. A prescindere da quale sia la loro origine, i dragonidi si sono ormai stabiliti nel Piano Materiale.\n\nI dragonidi sembrano draghi bipedi senza ali, con squame, occhi luminosi, ossa spesse e corna sulle loro teste. La colorazione e altri tratti testimoniano il loro retaggio draconico."
					},
					new SpeciesTranslation
					{
						Language = LanguageCode.En,
						Name = "Dragonborn",
						Description = "The ancestors of dragonborn hatched from the eggs of chromatic and metallic dragons. One story holds that these eggs were blessed by the dragon gods Bahamut and Tiamat, who wanted to populate the multiverse with people created in their image. Another story claims that dragons created the first dragonborn without the gods' blessings. Whatever their origin, dragonborn have made homes for themselves on the Material Plane.\n\nDragonborn look like wingless, bipedal dragons—scaly, bright-eyed, and thick-boned with horns on their heads—and their coloration and other features are reminiscent of their draconic ancestors."
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
								Description = "Il personaggio ha scurovisione fino a un raggio di 18 metri."
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
								Name = "Soffio",
								Description = "Quando il personaggio esegue l'azione di Attacco durante il turno, può sostituire uno dei suoi attacchi con un’esalazione di energia magica in un cono di 4,5 metri o in una linea lunga 9 metri e larga 1,5 (puoi scegliere la forma a ogni utilizzo). Ogni creatura nell'area deve effettuare un tiro salvezza su Destrezza (CD 8 più il modificatore di Costituzione e il bonus di competenza del personaggio). In caso di fallimento, vengono inflitti 1d10 danni del tipo determinato dal tratto Discendenza draconica. Invece, in caso di successo, la creatura colpita subisce soltanto la metà di quei danni. I danni aumentano di 1d10 quando il personaggio raggiunge il 5° livello (2d10), l’11° livello (3d10) e il 17° livello (4d10).\n\nIl personaggio può utilizzare il soffio un numero di volte pari al valore del suo bonus di competenza e recuperare tutti gli utilizzi spesi quando completa un riposo lungo."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Breath Weapon",
								Description = "When you take the Attack action on your turn, you can replace one of your attacks with an exhalation of magical energy in either a 15-foot Cone or a 30-foot Line that is 5 feet wide (choose the shape each time). Each creature in that area must make a Dexterity saving throw (DC 8 plus your Constitution modifier and Proficiency Bonus). On a failed save, a creature takes 1d10 damage of the type determined by your Draconic Ancestry trait. On a successful save, a creature takes half as much damage. This damage increases by 1d10 when you reach character levels 5 (2d10), 11 (3d10), and 17 (4d10). You can use this Breath Weapon a number of times equal to your Proficiency Bonus, and you regain all expended uses when you finish a Long Rest."
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
								Name = "Resistenza ai danni",
								Description = "Il personaggio dispone di resistenza ai danni del tipo determinato dal tratto Discendenza draconica."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Damage Resistance",
								Description = "You have Resistance to the damage type determined by your Draconic Ancestry trait."
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
								Name = "Volo draconico",
								Description = "Quando il personaggio raggiunge il 5° livello, può incanalare dell'energia draconica per volare temporaneamente. Come azione bonus, può far spuntare delle ali spettrali dalla sua schiena che durano per 10 minuti, fino al momento in cui decide di farle scomparire (nessuna azione richiesta) o finché non diventa incapacitato. Durante quel periodo, è dotato di una velocità di volo pari alla sua velocità. L'aspetto delle ali varia in base al tipo di energia del soffio. Dopo aver usato questo tratto, il personaggio non può riutilizzarlo prima di aver completato un riposo lungo."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Draconic Flight",
								Description = "When you reach character level 5, you can channel draconic magic to give yourself temporary flight. As a Bonus Action, you sprout spectral wings on your back that last for 10 minutes or until you retract the wings (no action required) or have the Incapacitated condition. During that time, you have a Fly Speed equal to your Speed. Your wings appear to be made of the same energy as your Breath Weapon. Once you use this trait, you can't use it again until you finish a Long Rest."
							}
						}
					}
				},
				Subspecies = Ancestors.Select(anc => new Subspecies
				{
					Id = anc.Id,
					Ruleset = RulesetVersion.Dnd5e_2024,
					IsOfficialSRD = true,
					Translations = new List<SubspeciesTranslation>
					{
						new SubspeciesTranslation
						{
							Language = LanguageCode.It,
							Name = anc.NameIt,
							Description = $"Discendenza legata al {anc.NameIt}. Determina il tipo di danno ({anc.DamageTypeIt}) per il Soffio, la Resistenza ai danni e l'aspetto delle ali di Volo draconico."
						},
						new SubspeciesTranslation
						{
							Language = LanguageCode.En,
							Name = anc.NameEn,
							Description = $"Lineage tied to the {anc.NameEn}. Dictates the damage type ({anc.DamageTypeEn}) for your Breath Weapon, Damage Resistance, and appearance of Draconic Flight wings."
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
									Name = $"Elemento: {anc.DamageTypeIt}",
									Description = $"Il tuo Soffio infligge danni da {anc.DamageTypeIt} e godi di Resistenza ai danni da {anc.DamageTypeIt}."
								},
								new TraitTranslation
								{
									Language = LanguageCode.En,
									Name = $"Element: {anc.DamageTypeEn}",
									Description = $"Your Breath Weapon deals {anc.DamageTypeEn} damage, and you have Resistance to {anc.DamageTypeEn} damage."
								}
							}
						}
					}
				}).ToList()
			};

			context.Species.Add(dragonborn);
			await context.SaveChangesAsync();
		}
	}
}