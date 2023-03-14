namespace Employees.Application;

public record AddEmployeesCommand(IEnumerable<Employee> Employees) : IRequest<IEnumerable<Employee>>;
