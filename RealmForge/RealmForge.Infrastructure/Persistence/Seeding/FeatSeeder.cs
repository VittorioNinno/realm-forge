using RealmForge.Infrastructure.Persistence.Seeding.FeatsData;

namespace RealmForge.Infrastructure.Persistence.Seeding;

///	<summary>
///	Orchestrates the automated database seeding for feats at application startup.
///	</summary>
public static class FeatSeeder
{
	///	<summary>
	///	Asynchronously executes all individual feat seeders.
	///	</summary>
	///	<param name="context">The database context instance.</param>
	public static async Task SeedAsync(RealmForgeDbContext context)
	{
		//	Official SRD 2014 (5e)
		await Alert2014Seeder.SeedAsync(context);
		await Athlete2014Seeder.SeedAsync(context);
		await Actor2014Seeder.SeedAsync(context);
		await Charger2014Seeder.SeedAsync(context);
		await CrossbowExpert2014Seeder.SeedAsync(context);
		await DefensiveDuelist2014Seeder.SeedAsync(context);
		await DualWielder2014Seeder.SeedAsync(context);
		await DungeonDelver2014Seeder.SeedAsync(context);
		await Durable2014Seeder.SeedAsync(context);
		await ElementalAdept2014Seeder.SeedAsync(context);
		await Grappler2014Seeder.SeedAsync(context);
		await GreatWeaponMaster2014Seeder.SeedAsync(context);
		await Healer2014Seeder.SeedAsync(context);
		await HeavilyArmored2014Seeder.SeedAsync(context);
		await HeavyArmorMaster2014Seeder.SeedAsync(context);
		await InspiringLeader2014Seeder.SeedAsync(context);
		await KeenMind2014Seeder.SeedAsync(context);
		await LightlyArmored2014Seeder.SeedAsync(context);
		await Linguist2014Seeder.SeedAsync(context);
		await Lucky2014Seeder.SeedAsync(context);
		await MageSlayer2014Seeder.SeedAsync(context);
		await MagicInitiate2014Seeder.SeedAsync(context);
		await MartialAdept2014Seeder.SeedAsync(context);
		await MediumArmorMaster2014Seeder.SeedAsync(context);
		await Mobile2014Seeder.SeedAsync(context);
		await ModeratelyArmored2014Seeder.SeedAsync(context);
		await MountedCombatant2014Seeder.SeedAsync(context);
		await Observant2014Seeder.SeedAsync(context);
		await PolearmMaster2014Seeder.SeedAsync(context);
		await Resilient2014Seeder.SeedAsync(context);
		await RitualCaster2014Seeder.SeedAsync(context);
		await SavageAttacker2014Seeder.SeedAsync(context);
		await Sentinel2014Seeder.SeedAsync(context);
		await Sharpshooter2014Seeder.SeedAsync(context);
		await ShieldMaster2014Seeder.SeedAsync(context);
		await Skilled2014Seeder.SeedAsync(context);
		await Skulker2014Seeder.SeedAsync(context);
		await SpellSniper2014Seeder.SeedAsync(context);
		await TavernBrawler2014Seeder.SeedAsync(context);
		await Tough2014Seeder.SeedAsync(context);
		await WarCaster2014Seeder.SeedAsync(context);
		await WeaponMaster2014Seeder.SeedAsync(context);

		//	Official SRD 2024 (5.5e)
		await Alert2024Seeder.SeedAsync(context);
		await Crafter2024Seeder.SeedAsync(context);
		await Healer2024Seeder.SeedAsync(context);
		await Lucky2014Seeder.SeedAsync(context);
		await MagicInitiate2024Seeder.SeedAsync(context);
		await Musician2024Seeder.SeedAsync(context);
		await SavageAttacker2024Seeder.SeedAsync(context);
		await Skilled2024Seeder.SeedAsync(context);
		await TavernBrawler2024Seeder.SeedAsync(context);
		await Tough2024Seeder.SeedAsync(context);

		await AbilityScoreImprovement2024Seeder.SeedAsync(context);
		await Actor2024Seeder.SeedAsync(context);
		await Athlete2024Seeder.SeedAsync(context);
		await Charger2024Seeder.SeedAsync(context);
		await Chef2024Seeder.SeedAsync(context);
		await CrossbowExpert2024Seeder.SeedAsync(context);
		await Crusher2024Seeder.SeedAsync(context);
		await DefensiveDuelist2024Seeder.SeedAsync(context);
		await DualWielder2024Seeder.SeedAsync(context);
		await Durable2024Seeder.SeedAsync(context);
		await ElementalAdept2024Seeder.SeedAsync(context);
		await FeyTouched2024Seeder.SeedAsync(context);
		await Grappler2024Seeder.SeedAsync(context);
		await GreatWeaponMaster2024Seeder.SeedAsync(context);
		await HeavilyArmored2024Seeder.SeedAsync(context);
		await HeavyArmorMaster2024Seeder.SeedAsync(context);
		await InspiringLeader2024Seeder.SeedAsync(context);
		await KeenMind2024Seeder.SeedAsync(context);
		await LightlyArmored2024Seeder.SeedAsync(context);
		await MageSlayer2024Seeder.SeedAsync(context);
		await MartialWeaponTraining2024Seeder.SeedAsync(context);
		await MediumArmorMaster2024Seeder.SeedAsync(context);
		await ModeratelyArmored2024Seeder.SeedAsync(context);
		await MountedCombatant2024Seeder.SeedAsync(context);
		await Observant2024Seeder.SeedAsync(context);
		await Piercer2024Seeder.SeedAsync(context);
		await Poisoner2024Seeder.SeedAsync(context);
		await PolearmMaster2024Seeder.SeedAsync(context);
		await Resilient2024Seeder.SeedAsync(context);
		await RitualCaster2024Seeder.SeedAsync(context);
		await Sentinel2024Seeder.SeedAsync(context);
		await ShadowTouched2024Seeder.SeedAsync(context);
		await Sharpshooter2024Seeder.SeedAsync(context);
		await ShieldMaster2024Seeder.SeedAsync(context);
		await SkillExpert2024Seeder.SeedAsync(context);
		await Skulker2024Seeder.SeedAsync(context);
		await Slasher2024Seeder.SeedAsync(context);
		await Speedy2024Seeder.SeedAsync(context);
		await SpellSniper2024Seeder.SeedAsync(context);
		await Telekinetic2024Seeder.SeedAsync(context);
		await Telepathic2024Seeder.SeedAsync(context);
		await WarCaster2024Seeder.SeedAsync(context);
		await WeaponMaster2024Seeder.SeedAsync (context);

		await Archery2024Seeder.SeedAsync(context);
		await BlindFighting2024Seeder.SeedAsync(context);
		await Defense2024Seeder.SeedAsync(context);
		await Dueling2024Seeder.SeedAsync(context);
		await GreatWeaponFighting2024Seeder.SeedAsync(context);
		await Interception2024Seeder.SeedAsync(context);
		await Protection2024Seeder.SeedAsync(context);
		await ThrownWeaponFighting2024Seeder.SeedAsync(context);
		await TwoWeaponFighting2024Seeder.SeedAsync(context);
		await UnarmedFighting2024Seeder.SeedAsync(context);

		await BoonOfCombatProwess2024Seeder.SeedAsync(context);
		await BoonOfDimensionalTravel2024Seeder.SeedAsync(context);
		await BoonOfEnergyResistance2024Seeder.SeedAsync(context);
		await BoonOfFate2024Seeder.SeedAsync(context);
		await BoonOfFortitude2024Seeder.SeedAsync(context);
		await BoonOfIrresistibleOffense2024Seeder.SeedAsync(context);
		await BoonOfRecovery2024Seeder.SeedAsync(context);
		await BoonOfSkill2024Seeder.SeedAsync(context);
		await BoonOfSpeed2024Seeder.SeedAsync(context);
		await BoonOfSpellRecall2024Seeder.SeedAsync(context);
		await BoonOfTheNightSpirit2024Seeder.SeedAsync(context);
		await BoonOfTruesight2024Seeder.SeedAsync(context);
	}
}