namespace Shared.Abstractions;

public interface IBaseRepository<TEntity, TContext> where TEntity : BaseEntity where TContext : IModuleDbContext<TEntity>
{
    Task<TEntity> GetAsync(Guid id);
    Task<IEnumerable<TEntity>> GetAsync();
    Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate);

    Task<TEntity> AddAsync(TEntity entity);
    Task<IEnumerable<TEntity>> AddAsync(IEnumerable<TEntity> entities);

    Task<TEntity> EditAsync(TEntity entity);
    Task<IEnumerable<TEntity>> EditAsync(IEnumerable<TEntity> entities);

    Task<TEntity> RemoveAsync(Guid id);
    Task<TEntity> RemoveAsync(TEntity entity);
    Task<IEnumerable<TEntity>> RemoveAsync(IEnumerable<TEntity> entities);

    Task<IDbContextTransaction> BeginTransaction();
}