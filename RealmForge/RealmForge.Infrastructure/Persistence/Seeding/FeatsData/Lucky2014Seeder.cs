using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;
using RealmForge.Domain.Enums;
using RealmForge.Infrastructure.Persistence;

namespace RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

///	<summary>
///	Provides deterministic database seeding for the Lucky feat (2014 ruleset).
///	</summary>
public static class Lucky2014Seeder
{
	public static readonly Guid FeatId = Guid.Parse("11111111-2222-3333-4444-555555555521");
	public static readonly Guid TranslationEnId = Guid.Parse("11111111-2222-3333-4444-555555555711");
	public static readonly Guid TranslationItId = Guid.Parse("11111111-2222-3333-4444-555555555712");

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
			Ruleset = RulesetVersion.Dnd5e_2014,
			IsOfficialSRD = true,
			Category = FeatCategory.General,
			Translations = new List<FeatTranslation>
			{
				new FeatTranslation
				{
					Id = TranslationEnId,
					Language = LanguageCode.En,
					Name = "Lucky",
					Description = "You have inexplicable luck that seems to kick in at just the right moment.\nYou have 3 luck points. Whenever you make an attack roll, an ability check, or a saving throw, you can spend one luck point to roll an additional d20. You can choose to spend one of your luck points after you roll the die, but before the outcome is determined. You choose which of the d20s is used for the attack roll, ability check, or saving throw.\nYou can also spend one luck point when an attack roll is made against you. Roll a d20, and then choose whether the attack uses the attacker's roll or yours.\nIf more than one creature spends a luck point to influence the outcome of a roll, the points cancel each other out; no additional dice are rolled.\nYou regain your expended luck points when you finish a long rest."
				},
				new FeatTranslation
				{
					Id = TranslationItId,
					Language = LanguageCode.It,
					Name = "Fortunato",
					Description = "Il personaggio è dotato di una fortuna sfacciata che sembra intervenire nei momenti più opportuni.\nIl personaggio possiede 3 punti fortuna. Ogni volta che effettua un tiro per colpire, una prova di caratteristica o un tiro salvezza, può spendere un punto fortuna per tirare un d20 aggiuntivo. Può scegliere di spendere uno dei suoi punti fortuna dopo che ha tirato il dado, ma prima che l'esito del tiro sia determinato. Il personaggio sceglie quale dei d20 usare per il tiro per colpire, la prova di caratteristica o il tiro salvezza.\nIl personaggio può anche spendere un punto fortuna quando viene effettuato un tiro per colpire contro di lui. Tira un d20, dopodiché sceglie se l'attacco utilizzerà il tiro dell'attaccante o il suo.\nSe più di una creatura spende un punto fortuna per influenzare l'esito di un tiro, i punti si annullano a vicenda e non si tira alcun dado aggiuntivo.\nIl personaggio recupera i punti fortuna spesi quando completa un riposo lungo."
				}
			}
		};

		context.Feats.Add(feat);
		await context.SaveChangesAsync();
	}
}