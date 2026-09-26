namespace RealmForge.Domain.Common;

public abstract class GameEntity
{
	public Guid Id { get; set; } = Guid.NewGuid();

	//	true se il dato fa parte delle regole aperte ufficiali (SRD), false se Homebrew
	public bool IsOfficialSRD { get; set; } = false;

	//	Se null è un contenuto base di sistema/SRD; altrimenti corrisponde all'identificativo dell'autore
	public string? AuthorId { get; set; }

	public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
	public DateTime? UpdatedAtUtc { get; set; }
}