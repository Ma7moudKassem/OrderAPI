using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Shared.Abstractions;

public interface IBaseGetRepository<TContext, TEntity>
    where TContext : IModuleDbContext<TEntity> where TEntity : BaseEntity
{
    Task<TEntity> GetAsync(Guid id);
    Task<IEnumerable<TEntity>> GetAsync();
    Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate);
}
