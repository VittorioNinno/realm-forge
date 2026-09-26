using RealmForge.Infrastructure.Persistence.Seeding.SpeciesData;

namespace RealmForge.Infrastructure.Persistence.Seeding
{
	public static class SpeciesSeeder
	{
		public static async Task SeedAsync(RealmForgeDbContext context)
		{
			//	Official SRD 2014 (5e)
			await Dwarf2014Seeder.SeedAsync(context);
			await Elf2014Seeder.SeedAsync(context);
			await Halfling2014Seeder.SeedAsync(context);
			await Human2014Seeder.SeedAsync(context);
			await Dragonborn2014Seeder.SeedAsync(context);
			await Gnome2014Seeder.SeedAsync(context);
			await HalfElf2014Seeder.SeedAsync(context);
			await HalfOrc2014Seeder.SeedAsync(context);
			await Tiefling2014Seeder.SeedAsync(context);

			//	Official SRD 2024 (5.5e)
			await Aasimar2024Seeder.SeedAsync(context);
			await Dragonborn2024Seeder.SeedAsync(context);
			await Dwarf2024Seeder.SeedAsync(context);
			await Elf2024Seeder.SeedAsync(context);
			await Gnome2024Seeder.SeedAsync(context);
			await Goliath2024Seeder.SeedAsync(context);
			await Halfling2024Seeder.SeedAsync(context);
			await Human2024Seeder.SeedAsync(context);
			await Orc2024Seeder.SeedAsync(context);
			await Tiefling2024Seeder.SeedAsync(context);
		}
	}
}