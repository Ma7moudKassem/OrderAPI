using Shared.Abstractions;

namespace Shared.Infrastructure
{
    public class BaseRepository<TContext, TEntity> : BaseGetRepository<TContext, TEntity> ,IBaseRepository<TContext, TEntity>
        where TContext : IModuleDbContext<TEntity> where TEntity : BaseEntity
    {
        public BaseRepository(TContext context) : base(context) { }
    }
}