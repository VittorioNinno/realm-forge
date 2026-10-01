using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the War Caster feat (2014 ruleset).
///	</summary>
public static class WarCaster2014Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555542");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555921");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555922");

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
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Category = FeatCategory.General,
			Prerequisite = "The ability to cast at least one spell",
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "War Caster",
					Description = "You have practiced casting spells in the midst of combat, learning techniques that grant you the following benefits:\n- You have advantage on Constitution saving throws that you make to maintain your concentration on a spell when you take damage.\n- You can perform the somatic components of spells even when you have weapons or a shield in one or both hands.\n- When a hostile creature's movement provokes an opportunity attack from you, you can use your reaction to cast a spell at the creature, rather than making an opportunity attack. The spell must have a casting time of 1 action and must target only that creature."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Incantatore da Guerra",
					Description = "Il personaggio si è allenato a lanciare incantesimi nel bel mezzo di un combattimento e ha appreso le tecniche che gli forniscono i benefici seguenti:\n- Dispone di vantaggio ai tiri salvezza su Costituzione che effettua per mantenere la concentrazione su un incantesimo quando subisce danni.\n- Può fornire le componenti somatiche degli incantesimi anche quando impugna armi o uno scudo con una o entrambe le mani.\n- Quando il movimento di una creatura ostile provoca un attacco di opportunità da parte sua, il personaggio può usare la sua reazione per lanciare un incantesimo sulla creatura anziché effettuare un attacco di opportunità. L'incantesimo deve avere un tempo di lancio di 1 azione e deve bersagliare solo quella creatura."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}