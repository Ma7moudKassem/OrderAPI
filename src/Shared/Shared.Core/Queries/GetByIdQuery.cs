namespace Shared.Core;

public record GetByIdQuery<TEntity>(Guid id) : IRequest<TEntity> 
    where TEntity : BaseEntity;