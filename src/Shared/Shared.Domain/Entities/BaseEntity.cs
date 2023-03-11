namespace Shared.Domain;

public class BaseEntity
{
    public Guid Id { get; set; }
    public DateTime SystemCreationTime { get; set; } = DateTime.Now;
}