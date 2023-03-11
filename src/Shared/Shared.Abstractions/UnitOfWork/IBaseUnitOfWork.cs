using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Shared.Abstractions;

public interface IBaseUnitOfWork<TContext, TEntity> : IBaseGetUnitOfWork<TContext, TEntity>
    where TContext : IModuleDbContext<TEntity> where TEntity : BaseEntity
{

}
