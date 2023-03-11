namespace Shared.Abstractions;

public interface IBaseRepository<TEntity> : IBaseGetRepository<TEntity> where TEntity : BaseEntity
{
}