namespace Shared.Infrastructure;

public abstract class ModuleDbContext : DbContext
{
    protected abstract string Schema { get; }

    public ModuleDbContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        if (string.IsNullOrWhiteSpace(Schema)) modelBuilder.HasDefaultSchema(Schema);

        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        => base.SaveChangesAsync(true, cancellationToken);
}
