namespace Shared.Core;

public class BaseEntity
{
    public Guid Id { get; set; }
    public DateTime SystemCreationTime { get; set; } = DateTime.Now;
}