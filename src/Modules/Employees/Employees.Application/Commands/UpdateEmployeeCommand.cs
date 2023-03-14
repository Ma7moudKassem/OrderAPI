namespace Employees.Application;

public record UpdateEmployeeCommand(Employee Employee) : IRequest<Employee>;