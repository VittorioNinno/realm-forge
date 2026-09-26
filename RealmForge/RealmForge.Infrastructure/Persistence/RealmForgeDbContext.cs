using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;

namespace RealmForge.Infrastructure.Persistence
{
	public class RealmForgeDbContext : DbContext
	{
		public RealmForgeDbContext(DbContextOptions<RealmForgeDbContext> options)
			: base(options)
		{
		}

		public DbSet<Species> Species => Set<Species>();
		public DbSet<SpeciesTranslation> SpeciesTranslations => Set<SpeciesTranslation>();

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			//	Species configuration
			modelBuilder.Entity<Species>(entity =>
			{
				entity.HasKey(e => e.Id);
				entity.Property(e => e.BaseSpeedInFeet).IsRequired();
				entity.Property(e => e.CreatureType).IsRequired();
				entity.Property(e => e.AllowedSizes).IsRequired();

				//	One-to-many relationship with translations
				entity.HasMany(e => e.Translations)
						.WithOne(t => t.Species)
						.HasForeignKey(t => t.SpeciesId)
						.OnDelete(DeleteBehavior.Cascade);
			});

			//	Species translations configuration
			modelBuilder.Entity<SpeciesTranslation>(entity =>
			{
				entity.HasKey(t => t.Id);
				entity.Property(t => t.Name).HasMaxLength(150).IsRequired();
				entity.Property(t => t.Description).HasMaxLength(4000);

				//	Unique index: a species cannot have two translations for the same language
				entity.HasIndex(t => new { t.SpeciesId, t.Language }).IsUnique();
			});
		}
	}
}