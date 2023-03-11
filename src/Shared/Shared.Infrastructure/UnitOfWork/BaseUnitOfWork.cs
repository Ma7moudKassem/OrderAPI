namespace Shared.Infrastructure;

public class BaseUnitOfWork<TContext, TEntity> : BaseGetUnitOfWork<TContext, TEntity>, IBaseUnitOfWork<TContext, TEntity>
     where TContext : IModuleDbContext<TEntity> where TEntity : BaseEntity
{
    public BaseUnitOfWork(BaseGetRepository<TContext, TEntity> repository) : base(repository)
    {
    }
}
