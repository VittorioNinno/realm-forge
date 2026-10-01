using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Alert feat (2024 ruleset).
///	</summary>
public static class Alert2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555544");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555941");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555942");

	///	<summary>
	///	Asynchronously seeds the Alert feat if it does not already exist.
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
			Category = FeatCategory.Origin,
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Alert",
					Description = "You gain the following benefits:\n- Initiative Proficiency. When you roll Initiative, you can add your Proficiency Bonus to the roll.\n- Initiative Swap. Immediately after you roll Initiative, you can swap your Initiative with the Initiative of one willing ally in the same combat. You can't make this swap if you or the ally has the Incapacitated condition."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Allerta",
					Description = "Il personaggio ottiene i seguenti benefici:\n- Competenza in Iniziativa. Quando tiri per l'iniziativa, puoi aggiungere il bonus di competenza del personaggio al risultato del tiro.\n- Scambio di Iniziativa. Subito dopo aver tirato per l'iniziativa, puoi scambiare il risultato ottenuto con quello di un alleato consenziente durante il medesimo combattimento. Se il tuo personaggio o il suo alleato è incapacitato, non è possibile eseguire lo scambio."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}