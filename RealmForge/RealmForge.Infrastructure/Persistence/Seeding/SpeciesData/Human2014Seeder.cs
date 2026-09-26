using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;

namespace RealmForge.Infrastructure.Persistence.Seeding.SpeciesData
{
	public static class Human2014Seeder
	{
		//	Deterministic GUIDs for 2014 SRD Human aggregate
		public static readonly Guid SpeciesId = Guid.Parse("10000000-0000-0000-0000-000000000001");
		public static readonly Guid StandardHumanSubspeciesId = Guid.Parse("10000000-0000-0000-0003-000000000001");
		public static readonly Guid VariantHumanSubspeciesId = Guid.Parse("10000000-0000-0000-0003-000000000002");

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
				AllowedSizes = new List<CreatureSize> { CreatureSize.Medium },
				Ruleset = RulesetVersion.Dnd5e_2014,
				IsOfficialSRD = true,
				Translations = new List<SpeciesTranslation>
				{
					new SpeciesTranslation
					{
						Language = LanguageCode.It,
						Name = "Umano",
						Description = "Gli umani sono la razza comune più adattabile e ambiziosa. Presentano la maggiore varietà di gusti, credenze morali e usanze nelle molte regioni in cui si sono insediati. Erigono città destinate a sfidare il tempo e fondano grandi regni capaci di durare molti secoli."
					},
					new SpeciesTranslation
					{
						Language = LanguageCode.En,
						Name = "Human",
						Description = "Humans are the most adaptable and ambitious people among the common races. They have widely varying tastes, morals, and customs in the many different lands where they have settled. They build cities to last for the ages, and great kingdoms that can persist for long centuries."
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
								Name = "Linguaggi",
								Description = "Gli umani parlano, leggono e scrivono in Comune e in un linguaggio extra a scelta. Amano impreziosire la parlata con parole prese da altre lingue, imprecazioni o espressioni melodiche."
							},
							new TraitTranslation
							{
								Language = LanguageCode.En,
								Name = "Languages",
								Description = "You can speak, read, and write Common and one extra language of your choice. Humans typically learn the languages of other peoples they deal with."
							}
						}
					}
				},
				Subspecies = new List<Subspecies>
				{
					new Subspecies
					{
						Id = StandardHumanSubspeciesId,
						Ruleset = RulesetVersion.Dnd5e_2014,
						IsOfficialSRD = true,
						Translations = new List<SubspeciesTranslation>
						{
							new SubspeciesTranslation
							{
								Language = LanguageCode.It,
								Name = "Umano Standard",
								Description = "L'umano convenzionale, temprato da una naturale versatilità e determinazione diffusa in ogni campo."
							},
							new SubspeciesTranslation
							{
								Language = LanguageCode.En,
								Name = "Standard Human",
								Description = "The conventional human, marked by well-rounded versatility and drive across all endeavors."
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
										Name = "Incremento dei Punteggi di Caratteristica",
										Description = "Ciascuno dei sei punteggi di caratteristica aumenta di 1."
									},
									new TraitTranslation
									{
										Language = LanguageCode.En,
										Name = "Ability Score Increase",
										Description = "Your ability scores each increase by 1."
									}
								}
							}
						}
					},
					new Subspecies
					{
						Id = VariantHumanSubspeciesId,
						Ruleset = RulesetVersion.Dnd5e_2014,
						IsOfficialSRD = true,
						Translations = new List<SubspeciesTranslation>
						{
							new SubspeciesTranslation
							{
								Language = LanguageCode.It,
								Name = "Umano Variante",
								Description = "Se la campagna utilizza la regola facoltativa dei talenti, il Dungeon Master può autorizzare questa versione focalizzata su specializzazione e talento innato."
							},
							new SubspeciesTranslation
							{
								Language = LanguageCode.En,
								Name = "Variant Human",
								Description = "If your campaign uses optional feats, your Dungeon Master might allow these variant traits focused on specialized expertise."
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
										Name = "Incremento di Caratteristica Variante",
										Description = "Due punteggi di caratteristica diversi a scelta aumentano di 1 ciascuno."
									},
									new TraitTranslation
									{
										Language = LanguageCode.En,
										Name = "Ability Score Increase (Variant)",
										Description = "Two different ability scores of your choice increase by 1."
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
										Name = "Abilità",
										Description = "Ottieni competenza in un'abilità a tua scelta."
									},
									new TraitTranslation
									{
										Language = LanguageCode.En,
										Name = "Skills",
										Description = "You gain proficiency in one skill of your choice."
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
										Name = "Talento",
										Description = "Ottieni un talento a tua scelta."
									},
									new TraitTranslation
									{
										Language = LanguageCode.En,
										Name = "Feat",
										Description = "You gain one feat of your choice."
									}
								}
							}
						}
					}
				}
			};

			context.Species.Add(human);
			await context.SaveChangesAsync();
		}
	}
}