namespace Employees.Application;

public interface IEmployeeRepository : IBaseRepository<Employee, IEmployeesDbContext> { }