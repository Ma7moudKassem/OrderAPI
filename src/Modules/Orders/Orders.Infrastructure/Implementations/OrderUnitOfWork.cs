namespace Orders.Infrastructure;

public class OrderUnitOfWork : IOrderUnitOfWork
{
    IOrderRepository _repository;
    public OrderUnitOfWork(IOrderRepository repository) => _repository = repository;

    public async Task<Order> ReadAsync(Guid id) =>
        await _repository.GetAsync(id);
    public async Task<IEnumerable<Order>> ReadAsync() =>
        await _repository.GetAsync();
    public async Task<IEnumerable<Order>> ReadAsync(Expression<Func<Order, bool>> predicate) =>
        await _repository.GetAsync(predicate);

    public async Task<Order> CreateAsync(Order order)
    {
        using IDbContextTransaction transaction = await _repository.BeginTransaction();
        try
        {
            await _repository.AddAsync(order);

            if (transaction is not null) await transaction.CommitAsync();

            return order;
        }
        catch (Exception exception)
        {
            if (transaction is not null) await transaction.RollbackAsync();

            Log.Error(exception.GetExceptionErrorSimplified());
            throw;

        }
    }
    public async Task<IEnumerable<Order>> CreateAsync(IEnumerable<Order> orders)
    {
        using IDbContextTransaction transaction = await _repository.BeginTransaction();
        try
        {
            await _repository.AddAsync(orders);

            if (transaction is not null) await transaction.CommitAsync();

            return orders;
        }
        catch (Exception exception)
        {
            if (transaction is not null) await transaction.RollbackAsync();

            Log.Error(exception.GetExceptionErrorSimplified());
            throw;

        }
    }

    public async Task<Order> UpdateAsync(Order order)
    {
        using IDbContextTransaction transaction = await _repository.BeginTransaction();
        try
        {
            await _repository.EditAsync(order);

            if (transaction is not null) await transaction.CommitAsync();

            return order;
        }
        catch (Exception exception)
        {
            if (transaction is not null) await transaction.RollbackAsync();

            Log.Error(exception.GetExceptionErrorSimplified());
            throw;

        }
    }
    public async Task<IEnumerable<Order>> UpdateAsync(IEnumerable<Order> orders)
    {
        using IDbContextTransaction transaction = await _repository.BeginTransaction();
        try
        {
            await _repository.EditAsync(orders);

            if (transaction is not null) await transaction.CommitAsync();

            return orders;
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
    public async Task DeleteAsync(Order order)
    {
        using IDbContextTransaction transaction = await _repository.BeginTransaction();
        try
        {
            await _repository.RemoveAsync(order);

            if (transaction is not null) await transaction.CommitAsync();
        }
        catch (Exception exception)
        {
            if (transaction is not null) await transaction.RollbackAsync();

            Log.Error(exception.GetExceptionErrorSimplified());
            throw;

        }
    }
    public async Task DeleteAsync(IEnumerable<Order> orders)
    {
        using IDbContextTransaction transaction = await _repository.BeginTransaction();
        try
        {
            await _repository.RemoveAsync(orders);

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