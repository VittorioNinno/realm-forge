using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Linguist feat (2014 ruleset).
///	</summary>
public static class Linguist2014Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555520");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555701");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555702");

	///	<summary>
	///	Asynchronously seeds the Linguist feat if it does not already exist.
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
					Name = "Linguist",
					Description = "You have studied languages and codes, gaining the following benefits:\n- Increase your Intelligence score by 1, to a maximum of 20.\n- You learn three languages of your choice.\n- You can ably create written ciphers. Others can't decipher a code you create unless you teach them, they succeed on an Intelligence check (DC equal to your Intelligence score + your proficiency bonus), or they use magic to decipher it."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Linguista",
					Description = "Il personaggio ha studiato molte lingue e codici diversi, e ottiene i benefici seguenti:\n- Il suo punteggio di Intelligenza aumenta di 1, fino a un massimo di 20.\n- Apprende tre linguaggi a sua scelta.\n- È in grado di creare codici cifrati. Gli altri individui non possono decifrare il codice a meno che non vengano istruiti a farlo dal personaggio, o che non superino una prova di Intelligenza (CD pari al punteggio di Intelligenza del personaggio + il bonus di competenza del personaggio), oppure utilizzando una magia che consenta loro di decifrarli."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}