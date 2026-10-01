using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Lucky feat (2024 ruleset).
///	</summary>
public static class Lucky2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555547");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555971");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555972");

	///	<summary>
	///	Asynchronously seeds the Lucky feat if it does not already exist.
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
					Name = "Lucky",
					Description = "You gain the following benefits:\n- **Luck Points.** You have a number of Luck Points equal to your Proficiency Bonus and can spend the points on the benefits below. You regain your expended Luck Points when you finish a Long Rest.\n- **Advantage.** When you roll a d20 for a D20 Test, you can spend 1 Luck Point to give yourself Advantage on the roll.\n- **Disadvantage.** When a creature rolls a d20 for an attack roll against you, you can spend 1 Luck Point to impose Disadvantage on that roll."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Fortunato",
					Description = "Il personaggio ottiene i seguenti benefici:\n- **Punti Fortuna.** Il personaggio dispone di un numero di Punti Fortuna pari al suo bonus di competenza, che può consumare per i benefici elencati di seguito. I Punti Fortuna consumati vengono recuperati dopo aver completato un Riposo Lungo.\n- **Vantaggio.** Quando il personaggio effettua una prova con il d20, può consumare 1 Punto Fortuna per ottenere Vantaggio sul tiro.\n- **Svantaggio.** Quando una creatura effettua un tiro per colpire con il d20 contro il personaggio, può consumare 1 Punto Fortuna per conferire Svantaggio a quel tiro."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}