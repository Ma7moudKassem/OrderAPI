namespace Employees.Application;

public interface IEmployeeUnitOfWork : IBaseUnitOfWork<Employee, IEmployeesDbContext> { }