using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Musician feat (2024 ruleset).
///	</summary>
public static class Musician2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555549");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555991");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555992");

	///	<summary>
	///	Asynchronously seeds the Musician feat if it does not already exist.
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
					Name = "Musician",
					Description = "You gain the following benefits:\n- **Instrument Training.** You gain proficiency with three Musical Instruments of your choice.\n- **Encouraging Song.** As you finish a Short or Long Rest, you can play a song on a Musical Instrument with which you have proficiency and give Heroic Inspiration to allies who hear the song. The number of allies you can affect in this way equals your Proficiency Bonus."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Musicista",
					Description = "Il personaggio ottiene i seguenti benefici:\n- **Formazione Musicale.** Il personaggio ottiene competenza in tre strumenti musicali a tua scelta.\n- **Canzone Incoraggiante.** Dopo aver completato un Riposo Breve o Lungo, il personaggio può suonare una canzone utilizzando uno strumento in cui ha competenza, in modo da conferire Ispirazione Eroica agli alleati che la ascoltano. Il numero di alleati che possono beneficiare di questo effetto equivale al bonus di competenza del personaggio."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}