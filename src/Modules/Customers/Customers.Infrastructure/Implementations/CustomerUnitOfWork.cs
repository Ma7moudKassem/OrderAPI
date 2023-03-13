namespace Customers.Infrastructure;

public class CustomerUnitOfWork : ICustomerUnitOfWork
{
    ICustomerRepository _repository;
    public CustomerUnitOfWork(ICustomerRepository repository) => _repository = repository;

    public async Task<Customer> ReadAsync(Guid id) =>
        await _repository.GetAsync(id);
    public async Task<IEnumerable<Customer>> ReadAsync() =>
        await _repository.GetAsync();
    public async Task<IEnumerable<Customer>> ReadAsync(Expression<Func<Customer, bool>> predicate) =>
        await _repository.GetAsync(predicate);

    public async Task<Customer> CreateAsync(Customer customer)
    {
        using IDbContextTransaction transaction = await _repository.BeginTransaction();
        try
        {
            await _repository.AddAsync(customer);

            if (transaction is not null) await transaction.CommitAsync();

            return customer;
        }
        catch (Exception exception)
        {
            if (transaction is not null) await transaction.RollbackAsync();

            Log.Error(exception.Message);
            throw;

        }
    }
    public async Task<IEnumerable<Customer>> CreateAsync(IEnumerable<Customer> customers)
    {
        using IDbContextTransaction transaction = await _repository.BeginTransaction();
        try
        {
            await _repository.AddAsync(customers);

            if (transaction is not null) await transaction.CommitAsync();

            return customers;
        }
        catch (Exception exception)
        {
            if (transaction is not null) await transaction.RollbackAsync();

            Log.Error(exception.Message);
            throw;

        }
    }

    public async Task<Customer> UpdateAsync(Customer customer)
    {
        using IDbContextTransaction transaction = await _repository.BeginTransaction();
        try
        {
            await _repository.EditAsync(customer);

            if (transaction is not null) await transaction.CommitAsync();

            return customer;
        }
        catch (Exception exception)
        {
            if (transaction is not null) await transaction.RollbackAsync();

            Log.Error(exception.Message);
            throw;

        }
    }
    public async Task<IEnumerable<Customer>> UpdateAsync(IEnumerable<Customer> customers)
    {
        using IDbContextTransaction transaction = await _repository.BeginTransaction();
        try
        {
            await _repository.EditAsync(customers);

            if (transaction is not null) await transaction.CommitAsync();

            return customers;
        }
        catch (Exception exception)
        {
            if (transaction is not null) await transaction.RollbackAsync();

            Log.Error(exception.Message);
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

            Log.Error(exception.Message);
            throw;

        }
    }
    public async Task DeleteAsync(Customer customer)
    {
        using IDbContextTransaction transaction = await _repository.BeginTransaction();
        try
        {
            await _repository.RemoveAsync(customer);

            if (transaction is not null) await transaction.CommitAsync();
        }
        catch (Exception exception)
        {
            if (transaction is not null) await transaction.RollbackAsync();

            Log.Error(exception.Message);
            throw;

        }
    }
    public async Task DeleteAsync(IEnumerable<Customer> customers)
    {
        using IDbContextTransaction transaction = await _repository.BeginTransaction();
        try
        {
            await _repository.RemoveAsync(customers);

            if (transaction is not null) await transaction.CommitAsync();
        }
        catch (Exception exception)
        {
            if (transaction is not null) await transaction.RollbackAsync();

            Log.Error(exception.Message);
            throw;

        }
    }
}