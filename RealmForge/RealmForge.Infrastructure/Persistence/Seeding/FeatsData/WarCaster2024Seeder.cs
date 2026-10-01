using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the War Caster feat (2024 ruleset).
///	</summary>
public static class WarCaster2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555595");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551451");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551452");

	///	<summary>
	///	Asynchronously seeds the War Caster feat if it does not already exist.
	///	</summary>
	///	<param name="context">The database context instance.</param>
	public static async Task SeedAsync(RealmForgeDbContext context)
	{
		if (await context.Feats.AnyAsync(f => f.Id == FeatId))
		{
			return;
		}

		var feat = new Feat
		{
			Id = FeatId,
			Ruleset = RulesetVersion.Dnd5e_2024,
			IsOfficialSRD = true,
			Category = FeatCategory.General,
			Prerequisite = "Level 4+, Spellcasting or Pact Magic Feature",
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "War Caster",
					Description = "You gain the following benefits:\n- **Ability Score Increase.** Increase your Intelligence, Wisdom, or Charisma score by 1, to a maximum of 20.\n- **Concentration.** You have Advantage on Constitution saving throws that you make to maintain Concentration.\n- **Reactive Spell.** When a creature provokes an Opportunity Attack from you by leaving your reach, you can take a Reaction to cast a spell at the creature rather than making an Opportunity Attack. The spell must have a casting time of one action and must target only that creature.\n- **Somatic Components.** You can perform the Somatic components of spells even when you have weapons or a Shield in one or both hands."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Incantatore da Guerra",
					Description = "Il personaggio ottiene i seguenti benefici:\n- **Incremento dei Punteggi di Caratteristica.** Il suo punteggio di Intelligenza, Saggezza o Carisma aumenta di 1, fino a un massimo di 20.\n- **Concentrazione.** Il personaggio ha Vantaggio ai tiri salvezza su Costituzione che effettua per mantenere la Concentrazione.\n- **Incantesimo Reattivo.** Quando una creatura provoca un Attacco di Opportunità dal personaggio uscendo dalla sua portata, il personaggio può usare una Reazione per lanciare un incantesimo contro la creatura anziché effettuare un Attacco di Opportunità. L'incantesimo deve avere un tempo di lancio di un'Azione e avere come unico bersaglio quella creatura.\n- **Componenti Somatiche.** Il personaggio può eseguire le componenti somatiche degli incantesimi persino quando ha una o entrambe le mani occupate con delle armi o uno scudo."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}