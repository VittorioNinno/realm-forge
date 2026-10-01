using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Great Weapon Master feat (2014 ruleset).
///	</summary>
public static class GreatWeaponMaster2014Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555513");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555631");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555632");

	///	<summary>
	///	Asynchronously seeds the Great Weapon Master feat if it does not already exist.
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
					Name = "Great Weapon Master",
					Description = "You've learned to put the weight of a weapon to your advantage, letting its momentum empower your strikes. You gain the following benefits:\n- On your turn, when you score a critical hit with a melee weapon or reduce a creature to 0 hit points with one, you can make one melee weapon attack as a bonus action.\n- Before you make a melee attack with a heavy weapon that you are proficient with, you can choose to take a -5 penalty to the attack roll. If the attack hits, you add +10 to the attack's damage."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Maestro d'Armi Possenti",
					Description = "Il personaggio ha imparato a sfruttare a proprio vantaggio il peso di un'arma, lasciando che il suo slancio infonda maggiore potenza ai suoi colpi. Ottiene i benefici seguenti:\n- Nel proprio turno, quando mette a segno un colpo critico con un'arma da mischia o porta un personaggio a 0 punti ferita con un attacco del genere, può effettuare un attacco con un'arma da mischia come azione bonus.\n- Prima di effettuare un attacco in mischia con un'arma pesante in cui è competente, può scegliere di subire una penalità di -5 al tiro per colpire. Se l'attacco colpisce, il personaggio aggiunge +10 ai danni dell'attacco."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}