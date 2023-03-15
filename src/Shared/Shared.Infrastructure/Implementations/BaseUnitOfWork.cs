namespace Shared.Infrastructure;

public class BaseUnitOfWork<TEntity, TContext> where TEntity : BaseEntity
    where TContext : IModuleDbContext<TEntity>
{
    IBaseRepository<TEntity, TContext> _repository;
    public BaseUnitOfWork(IBaseRepository<TEntity, TContext> repository) => _repository = repository;

    public async Task<TEntity> ReadAsync(Guid id) =>
        await _repository.GetAsync(id);
    public async Task<IEnumerable<TEntity>> ReadAsync() =>
        await _repository.GetAsync();
    public async Task<IEnumerable<TEntity>> ReadAsync(Expression<Func<TEntity, bool>> predicate) =>
        await _repository.GetAsync(predicate);

    public async Task<TEntity> CreateAsync(TEntity entity)
    {
        using IDbContextTransaction transaction = await _repository.BeginTransaction();
        try
        {
            await _repository.AddAsync(entity);

            if (transaction is not null) await transaction.CommitAsync();

            return entity;
        }
        catch (Exception exception)
        {
            if (transaction is not null) await transaction.RollbackAsync();

            Log.Error(exception.GetExceptionErrorSimplified());
            throw;

        }
    }
    public async Task<IEnumerable<TEntity>> CreateAsync(IEnumerable<TEntity> entities)
    {
        using IDbContextTransaction transaction = await _repository.BeginTransaction();
        try
        {
            await _repository.AddAsync(entities);

            if (transaction is not null) await transaction.CommitAsync();

            return entities;
        }
        catch (Exception exception)
        {
            if (transaction is not null) await transaction.RollbackAsync();

            Log.Error(exception.GetExceptionErrorSimplified());
            throw;

        }
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        using IDbContextTransaction transaction = await _repository.BeginTransaction();
        try
        {
            await _repository.EditAsync(entity);

            if (transaction is not null) await transaction.CommitAsync();

            return entity;
        }
        catch (Exception exception)
        {
            if (transaction is not null) await transaction.RollbackAsync();

            Log.Error(exception.GetExceptionErrorSimplified());
            throw;

        }
    }
    public async Task<IEnumerable<TEntity>> UpdateAsync(IEnumerable<TEntity> entities)
    {
        using IDbContextTransaction transaction = await _repository.BeginTransaction();
        try
        {
            await _repository.EditAsync(entities);

            if (transaction is not null) await transaction.CommitAsync();

            return entities;
        }
        catch (Exception exception)
        {
            if (transaction is not null) await transaction.RollbackAsync();

            Log.Error(exception.GetExceptionErrorSimplified());
            throw;

        }
    }

    public async Task DeleteAsync(Guid id)
    {
        using IDbContextTransaction transaction = await _repository.BeginTransaction();
        try
        {
            await _repository.RemoveAsync(id);

            if (transaction is not null) await transaction.CommitAsync();
        }
        catch (Exception exception)
        {
            if (transaction is not null) await transaction.RollbackAsync();

            Log.Error(exception.GetExceptionErrorSimplified());
            throw;

        }
    }
    public async Task DeleteAsync(TEntity entity)
    {
        using IDbContextTransaction transaction = await _repository.BeginTransaction();
        try
        {
            await _repository.RemoveAsync(entity);

            if (transaction is not null) await transaction.CommitAsync();
        }
        catch (Exception exception)
        {
            if (transaction is not null) await transaction.RollbackAsync();

            Log.Error(exception.GetExceptionErrorSimplified());
            throw;

        }
    }
    public async Task DeleteAsync(IEnumerable<TEntity> entities)
    {
        using IDbContextTransaction transaction = await _repository.BeginTransaction();
        try
        {
            await _repository.RemoveAsync(entities);

            if (transaction is not null) await transaction.CommitAsync();
        }
        catch (Exception exception)
        {
            if (transaction is not null) await transaction.RollbackAsync();

            Log.Error(exception.GetExceptionErrorSimplified());
            throw;

        }
    }
}
