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

		// Species aggregate
		public DbSet<Species> Species => Set<Species>();
		public DbSet<SpeciesTranslation> SpeciesTranslations => Set<SpeciesTranslation>();

		//	Subspecies and Lineages aggregate
		public DbSet<Subspecies> Subspecies => Set<Subspecies>();
		public DbSet<SubspeciesTranslation> SubspeciesTranslations => Set<SubspeciesTranslation>();

		//	Traits and Abilities aggregate
		public DbSet<Trait> Traits => Set<Trait>();
		public DbSet<TraitTranslation> TraitTranslations => Set<TraitTranslation>();

		public DbSet<Feat> Feats => Set<Feat>();
		public DbSet<FeatTranslation> FeatTranslations => Set<FeatTranslation>();

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
				entity.Property(e => e.Ruleset).IsRequired();
				entity.Property(e => e.IsOfficialSRD).IsRequired();

				//	One-to-many relationship with translations
				entity.HasMany(e => e.Translations)
						.WithOne(t => t.Species)
						.HasForeignKey(t => t.SpeciesId)
						.OnDelete(DeleteBehavior.Cascade);

				//	One-to-many relationship with subspecies/lineages
				entity.HasMany(e => e.Subspecies)
						.WithOne(s => s.Species)
						.HasForeignKey(s => s.SpeciesId)
						.OnDelete(DeleteBehavior.Cascade);

				//	One-to-many relationship with base traits
				entity.HasMany(e => e.Traits)
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

			//	Subspecies configuration
			modelBuilder.Entity<Subspecies>(entity =>
			{
				entity.HasKey(e => e.Id);
				entity.Property(e => e.Ruleset).IsRequired();
				entity.Property(e => e.IsOfficialSRD).IsRequired();

				//	One-to-many relationship with translations
				entity.HasMany(e => e.Translations)
						.WithOne(t => t.Subspecies)
						.HasForeignKey(t => t.SubspeciesId)
						.OnDelete(DeleteBehavior.Cascade);

				//	One-to-many relationship with exclusive traits
				entity.HasMany(e => e.Traits)
						.WithOne(t => t.Subspecies)
						.HasForeignKey(t => t.SubspeciesId)
						.OnDelete(DeleteBehavior.Cascade);
			});

			//	Subspecies translations configuration
			modelBuilder.Entity<SubspeciesTranslation>(entity =>
			{
				entity.HasKey(t => t.Id);
				entity.Property(t => t.Name).HasMaxLength(150).IsRequired();
				entity.Property(t => t.Description).HasMaxLength(4000);

				//	Unique index: a subspecies cannot have two translations for the same language
				entity.HasIndex(t => new { t.SubspeciesId, t.Language }).IsUnique();
			});

			//	Trait configuration
			modelBuilder.Entity<Trait>(entity =>
			{
				entity.HasKey(e => e.Id);
				entity.Property(e => e.RequiredLevel).IsRequired().HasDefaultValue(1);
				entity.Property(e => e.Ruleset).IsRequired();
				entity.Property(e => e.IsOfficialSRD).IsRequired();

				//	One-to-many relationship with translations
				entity.HasMany(e => e.Translations)
						.WithOne(t => t.Trait)
						.HasForeignKey(t => t.TraitId)
						.OnDelete(DeleteBehavior.Cascade);
			});

			//	Trait translations configuration
			modelBuilder.Entity<TraitTranslation>(entity =>
			{
				entity.HasKey(t => t.Id);
				entity.Property(t => t.Name).HasMaxLength(150).IsRequired();
				entity.Property(t => t.Description).HasMaxLength(4000);

				//	Unique index: a trait cannot have two translations for the same language
				entity.HasIndex(t => new { t.TraitId, t.Language }).IsUnique();
			});

			//	Feats configuration
			modelBuilder.Entity<Feat>(entity =>
			{
				entity.HasKey(f => f.Id);
				entity.HasMany(f => f.Translations)
						.WithOne(t => t.Feat)
						.HasForeignKey(t => t.FeatId)
						.OnDelete(DeleteBehavior.Cascade);
			});

			//	Feats translations configuration
			modelBuilder.Entity<FeatTranslation>(entity =>
			{
				entity.HasKey(t => t.Id);
				entity.Property(t => t.Name).IsRequired().HasMaxLength(150);
				entity.Property(t => t.Description).IsRequired();
			});
		}
	}
}