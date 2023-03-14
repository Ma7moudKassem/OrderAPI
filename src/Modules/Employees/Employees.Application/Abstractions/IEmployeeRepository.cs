namespace Employees.Application;

public interface IEmployeeRepository
{
    Task<Employee> GetAsync(Guid id);
    Task<IEnumerable<Employee>> GetAsync();
    Task<IEnumerable<Employee>> GetAsync(Expression<Func<Employee, bool>> predicate);

    Task<Employee> AddAsync(Employee employee);
    Task<IEnumerable<Employee>> AddAsync(IEnumerable<Employee> employees);

    Task<Employee> EditAsync(Employee employee);
    Task<IEnumerable<Employee>> EditAsync(IEnumerable<Employee> employees);

    Task RemoveAsync(Guid id);
    Task RemoveAsync(Employee employee);
    Task RemoveAsync(IEnumerable<Employee> employees);

    Task<IDbContextTransaction> BeginTransaction();
}