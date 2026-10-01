using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Shield Master feat (2014 ruleset).
///	</summary>
public static class ShieldMaster2014Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555536");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555861");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555862");

	///	<summary>
	///	Asynchronously seeds the Shield Master feat if it does not already exist.
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
					Name = "Shield Master",
					Description = "You use shields not just for protection but also for offense. You gain the following benefits while you are wielding a shield:\n- If you take the Attack action on your turn, you can use a bonus action to try to shove a creature within 5 feet of you with your shield.\n- If you aren't incapacitated, you can add your shield's AC bonus to any Dexterity saving throw you make against a spell or other harmful effect that targets only you.\n- If you are subjected to an effect that allows you to make a Dexterity saving throw to take only half damage, you can use your reaction to take no damage if you succeed on the saving throw, interposing your shield between yourself and the source of the effect."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Maestro degli Scudi",
					Description = "Il personaggio usa gli scudi non solo per proteggersi, ma anche per attaccare. Finché impugna uno scudo, ottiene i benefici seguenti:\n- Se effettua l'azione di Attacco nel suo turno, può usare un'azione bonus per cercare di spingere con il suo scudo una creatura entro 1,5 metri da sé.\n- Se non è incapacitato, può aggiungere il bonus di CA del suo scudo a qualsiasi tiro salvezza su Destrezza che effettui contro un incantesimo o un altro effetto dannoso che bersaglia soltanto lui.\n- Se è soggetto a un effetto che gli consente di effettuare un tiro salvezza su Destrezza per subire solo la metà dei danni, può usare la sua reazione per non subire alcun danno qualora superi il tiro salvezza, frapponendo lo scudo tra se stesso e la fonte dell'effetto."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}