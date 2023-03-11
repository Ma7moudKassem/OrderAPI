using Shared.Abstractions;

namespace Shared.Infrastructure;

public class ModuleDbContext<TEntity> : IdentityDbContext<ApplicationUser>, 
    IModuleDbContext<TEntity> where TEntity : BaseEntity
{
    DbSet<TEntity> IModuleDbContext<TEntity>.dbSet { get; set; }

    string Schema => throw new NotImplementedException();

    string IModuleDbContext<TEntity>.Schema => throw new NotImplementedException();

    public ModuleDbContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        if (string.IsNullOrWhiteSpace(IModuleDbContext<TEntity>.Schema)) modelBuilder.HasDefaultSchema(IModuleDbContext<TEntity>.Schema);

        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        => base.SaveChangesAsync(true, cancellationToken);
}
