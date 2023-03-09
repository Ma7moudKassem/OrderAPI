namespace Shared.Core;

public class GetHandler<TIContext, TEntity> : IRequestHandler<GetQuery<TEntity>, IEnumerable<TEntity>>
    where TEntity : BaseEntity 
{
    public virtual Task<IEnumerable<TEntity>> Handle(GetQuery<TEntity> request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
