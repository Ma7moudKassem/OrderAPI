namespace Employees.Application;

public record DeleteEmployeesCommand(IEnumerable<Employee> Employees) : IRequest;