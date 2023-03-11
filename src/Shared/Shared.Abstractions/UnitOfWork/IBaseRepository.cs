using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace Shared.Abstractions;

public interface IBaseRepository<TContext, TEntity> : IBaseGetRepository<TContext, TEntity>
    where TContext : IModuleDbContext<TEntity> where TEntity : BaseEntity
{
}