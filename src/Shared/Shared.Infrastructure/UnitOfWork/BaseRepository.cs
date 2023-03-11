namespace Shared.Infrastructure
{
    public class BaseRepository<TContext, TEntity> : BaseGetRepository<TContext, TEntity>
        where TContext : ModuleDbContext where TEntity : BaseEntity
    {
        public BaseRepository(TContext context) : base(context) { }
    }
}