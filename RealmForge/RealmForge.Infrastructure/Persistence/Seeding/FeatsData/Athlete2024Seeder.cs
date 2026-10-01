using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Athlete feat (2024 ruleset).
///	</summary>
public static class Athlete2024Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555556");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555551061");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555551062");

	///	<summary>
	///	Asynchronously seeds the Athlete feat if it does not already exist.
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
			Prerequisite = "Level 4+, Strength or Dexterity 13+",
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Athlete",
					Description = "You gain the following benefits:\n- **Ability Score Increase.** Increase your Strength or Dexterity score by 1, to a maximum of 20.\n- **Climb Speed.** You gain a Climb Speed equal to your Speed.\n- **Hop Up.** When you have the Prone condition, you can right yourself with only 5 feet of movement.\n- **Jumping.** You can make a running Long or High Jump after moving only 5 feet."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Atleta",
					Description = "Il personaggio ottiene i seguenti benefici:\n- **Incremento dei Punteggi di Caratteristica.** Il suo punteggio di Forza o Destrezza aumenta di 1, fino a un massimo di 20.\n- **Velocità di Scalata.** Il personaggio ottiene una velocità di scalata pari alla propria velocità.\n- **Rialzarsi.** Se il personaggio è prono, può rimettersi in piedi usando solo 1,5 metri di movimento.\n- **Saltare.** Il personaggio può eseguire un salto in alto o in lungo in corsa dopo aver percorso solo 1,5 metri."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}