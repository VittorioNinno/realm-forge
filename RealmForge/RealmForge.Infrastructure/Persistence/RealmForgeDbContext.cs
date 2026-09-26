using Microsoft.EntityFrameworkCore;
using RealmForge.Domain.Entities;

namespace RealmForge.Infrastructure.Persistence;

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

		//	Configurazione Specie
		modelBuilder.Entity<Species>(entity =>
		{
			entity.HasKey(e => e.Id);
			entity.Property(e => e.Size).HasMaxLength(30).IsRequired();

			//	Relazione 1 a Molti con le traduzioni
			entity.HasMany(e => e.Translations)
				  .WithOne(t => t.Species)
				  .HasForeignKey(t => t.SpeciesId)
				  .OnDelete(DeleteBehavior.Cascade);
		});

		//	Configurazione Traduzioni Specie
		modelBuilder.Entity<SpeciesTranslation>(entity =>
		{
			entity.HasKey(t => t.Id);
			entity.Property(t => t.Name).HasMaxLength(150).IsRequired();
			entity.Property(t => t.Description).HasMaxLength(4000);

			//	Indice univoco: una specie non può avere due traduzioni per la stessa lingua
			entity.HasIndex(t => new { t.SpeciesId, t.Language }).IsUnique();
		});
	}
}