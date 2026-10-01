using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Martial Adept feat (2014 ruleset).
///	</summary>
public static class MartialAdept2014Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555524");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555741");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555742");

	///	<summary>
	///	Asynchronously seeds the Martial Adept feat if it does not already exist.
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
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Category = FeatCategory.General,
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Martial Adept",
					Description = "You have martial training that allows you to perform special combat maneuvers. You gain the following benefits:\n- You learn two maneuvers of your choice from among those available to the Battle Master archetype in the fighter class. If a maneuver you use requires your target to make a saving throw to resist the maneuver's effects, the saving throw DC equals 8 + your proficiency bonus + your Strength or Dexterity modifier (your choice).\n- If you already have superiority dice, you gain one more; otherwise, you have one superiority die, which is a d6. This die is used to fuel your maneuvers. A superiority die is expended when you use it. You regain your expended superiority dice when you finish a short or long rest."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Adepto Marziale",
					Description = "Il personaggio si è sottoposto a un addestramento marziale che gli permette di effettuare alcune manovre speciali in combattimento. Ottiene i benefici seguenti:\n- Impara due manovre a sua scelta tra quelle disponibili per l'archetipo del Maestro di Battaglia nella classe del guerriero. Se una manovra da lui utilizzata richiede che il bersaglio effettui un tiro salvezza per resistere agli effetti della manovra, la CD del tiro salvezza è pari a 8 + il bonus di competenza del personaggio + il modificatore di Forza o di Destrezza del personaggio (a scelta del personaggio).\n- Ottiene un dado di superiorità, un d6 (in aggiunta agli eventuali dadi di superiorità forniti da un'altra fonte). Usa questo dado per alimentare le sue manovre. Un dado di superiorità è considerato speso quando il personaggio lo usa. Il personaggio recupera i dadi di superiorità spesi quando completa un riposo breve o lungo."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}