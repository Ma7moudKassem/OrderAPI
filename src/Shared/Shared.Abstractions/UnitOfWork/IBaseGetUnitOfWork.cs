namespace Shared.Abstractions;

public interface IBaseGetUnitOfWork<TEntity> where TEntity : BaseEntity
{
    Task<TEntity> ReadAsync(Guid id);

    Task<IEnumerable<TEntity>> ReadAsync();
    Task<IEnumerable<TEntity>> ReadAsync(Expression<Func<TEntity, bool>> predicate);
}
