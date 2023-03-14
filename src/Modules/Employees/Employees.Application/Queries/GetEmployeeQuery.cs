namespace Employees.Application;

public record GetEmployeeQuery() : IRequest<IEnumerable<Employee>>;
