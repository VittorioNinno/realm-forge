namespace RealmForge.Domain.Common;

public abstract class GameEntity
{
	public Guid Id { get; set; } = Guid.NewGuid();

	//	True if the data is part of the official System Reference Document (SRD), false if Homebrew
	public bool IsOfficialSRD { get; set; } = false;

	//	If null, it is base system/SRD content; otherwise, it corresponds to the author identifier
	public string? AuthorId { get; set; }

	public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
	public DateTime? UpdatedAtUtc { get; set; }
}