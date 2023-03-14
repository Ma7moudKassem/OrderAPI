namespace Employees.Application;

public interface IEmployeeUnitOfWork
{
    Task<Employee> ReadAsync(Guid id);

    Task<IEnumerable<Employee>> ReadAsync();
    Task<IEnumerable<Employee>> ReadAsync(Expression<Func<Employee, bool>> predicate);

    Task<Employee> CreateAsync(Employee employee);
    Task<IEnumerable<Employee>> CreateAsync(IEnumerable<Employee> employees);

    Task<Employee> UpdateAsync(Employee employee);
    Task<IEnumerable<Employee>> UpdateAsync(IEnumerable<Employee> employees);

    Task DeleteAsync(Guid id);
    Task DeleteAsync(Employee employee);
    Task DeleteAsync(IEnumerable<Employee> employees);
}