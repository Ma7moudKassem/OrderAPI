namespace Shared.Abstractions;

public interface IBaseRepository<TEntity, TContext> where TEntity : BaseEntity where TContext : IModuleDbContext<TEntity>
{
    Task<TEntity> GetAsync(Guid id);
    Task<IEnumerable<TEntity>> GetAsync();
    Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate);

    Task<TEntity> AddAsync(TEntity TEntity);
    Task<IEnumerable<TEntity>> AddAsync(IEnumerable<TEntity> TEntitys);

    Task<TEntity> EditAsync(TEntity TEntity);
    Task<IEnumerable<TEntity>> EditAsync(IEnumerable<TEntity> TEntitys);

    Task RemoveAsync(Guid id);
    Task RemoveAsync(TEntity TEntity);
    Task RemoveAsync(IEnumerable<TEntity> TEntitys);

    Task<IDbContextTransaction> BeginTransaction();
}