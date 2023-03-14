namespace Employees.Application;

public record UpdateEmployeesCommand(IEnumerable<Employee> Employees) : IRequest<IEnumerable<Employee>>;