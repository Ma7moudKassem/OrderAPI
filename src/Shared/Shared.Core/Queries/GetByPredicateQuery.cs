namespace Shared.Core;

public record GetByPredicateQuery<TEntity>(Expression<Func<TEntity, bool>> predicate) : IRequest<IEnumerable<TEntity>> 
    where TEntity : BaseEntity;