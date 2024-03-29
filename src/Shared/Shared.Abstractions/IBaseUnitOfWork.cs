﻿namespace Shared.Abstractions;

public interface IBaseUnitOfWork<TEntity, TContext> where TEntity : BaseEntity
    where TContext : IModuleDbContext<TEntity>
{
    Task<TEntity> ReadAsync(Guid id);

    Task<IEnumerable<TEntity>> ReadAsync();
    Task<IEnumerable<TEntity>> ReadAsync(Expression<Func<TEntity, bool>> predicate);

    Task<TEntity> CreateAsync(TEntity entity);
    Task<IEnumerable<TEntity>> CreateAsync(IEnumerable<TEntity> entities);

    Task<TEntity> UpdateAsync(TEntity entity);
    Task<IEnumerable<TEntity>> UpdateAsync(IEnumerable<TEntity> entities);

    Task<TEntity> DeleteAsync(Guid id);
    Task<TEntity> DeleteAsync(TEntity entity);
    Task<IEnumerable<TEntity>> DeleteAsync(IEnumerable<TEntity> entities);
}