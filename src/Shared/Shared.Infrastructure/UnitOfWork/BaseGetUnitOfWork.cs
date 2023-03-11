namespace Shared.Infrastructure;

public class BaseGetUnitOfWork<TContext, TEntity> : IBaseGetUnitOfWork<TContext,TEntity>
    where TContext : IModuleDbContext<TEntity> where TEntity : BaseEntity
{
    BaseGetRepository<TContext, TEntity> _repository;
    public BaseGetUnitOfWork(BaseGetRepository<TContext, TEntity> repository) =>
        _repository = repository;

    public virtual async Task<TEntity> ReadAsync(Guid id) =>
        await _repository.GetAsync(id);

    public virtual async Task<IEnumerable<TEntity>> ReadAsync() => 
        await _repository.GetAsync();

    public virtual async Task<IEnumerable<TEntity>> ReadAsync(Expression<Func<TEntity, bool>> predicate) =>
        await _repository.GetAsync(predicate);
}
