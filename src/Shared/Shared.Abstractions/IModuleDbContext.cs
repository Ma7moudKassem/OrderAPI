namespace Shared.Abstractions;

public interface IModuleDbContext<TEntity> where TEntity : BaseEntity
{
    DbSet<TEntity> entities { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    Task<IDbContextTransaction> BeginTransaction();
}