namespace Employees.Infrastructure;

public class EmployeeUnitOfWork : IEmployeeUnitOfWork
{
    readonly IEmployeeRepository _repository;
    public EmployeeUnitOfWork(IEmployeeRepository repository) => 
        _repository = repository;

    public async Task<Employee> ReadAsync(Guid id) =>
        await _repository.GetAsync(id);
    public async Task<IEnumerable<Employee>> ReadAsync() =>
        await _repository.GetAsync();
    public async Task<IEnumerable<Employee>> ReadAsync(Expression<Func<Employee, bool>> predicate) =>
        await _repository.GetAsync(predicate);

    public async Task<Employee> CreateAsync(Employee employee)
    {
        using IDbContextTransaction transaction = await _repository.BeginTransaction();
        try
        {
            await _repository.AddAsync(employee);

            if (transaction is not null) await transaction.CommitAsync();

            return employee;
        }
        catch (Exception exception)
        {
            if (transaction is not null) await transaction.RollbackAsync();

            Log.Error(exception.Message);
            throw;

        }
    }
    public async Task<IEnumerable<Employee>> CreateAsync(IEnumerable<Employee> employees)
    {
        using IDbContextTransaction transaction = await _repository.BeginTransaction();
        try
        {
            await _repository.AddAsync(employees);

            if (transaction is not null) await transaction.CommitAsync();

            return employees;
        }
        catch (Exception exception)
        {
            if (transaction is not null) await transaction.RollbackAsync();

            Log.Error(exception.Message);
            throw;

        }
    }

    public async Task<Employee> UpdateAsync(Employee employee)
    {
        using IDbContextTransaction transaction = await _repository.BeginTransaction();
        try
        {
            await _repository.EditAsync(employee);

            if (transaction is not null) await transaction.CommitAsync();

            return employee;
        }
        catch (Exception exception)
        {
            if (transaction is not null) await transaction.RollbackAsync();

            Log.Error(exception.Message);
            throw;

        }
    }
    public async Task<IEnumerable<Employee>> UpdateAsync(IEnumerable<Employee> employees)
    {
        using IDbContextTransaction transaction = await _repository.BeginTransaction();
        try
        {
            await _repository.EditAsync(employees);

            if (transaction is not null) await transaction.CommitAsync();

            return employees;
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
    public async Task DeleteAsync(Employee employee)
    {
        using IDbContextTransaction transaction = await _repository.BeginTransaction();
        try
        {
            await _repository.RemoveAsync(employee);

            if (transaction is not null) await transaction.CommitAsync();
        }
        catch (Exception exception)
        {
            if (transaction is not null) await transaction.RollbackAsync();

            Log.Error(exception.Message);
            throw;

        }
    }
    public async Task DeleteAsync(IEnumerable<Employee> employees)
    {
        using IDbContextTransaction transaction = await _repository.BeginTransaction();
        try
        {
            await _repository.RemoveAsync(employees);

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