namespace Shared.Core;

public record GetQuery<TEntity>() : IRequest<IEnumerable<TEntity>>
    where TEntity : BaseEntity;