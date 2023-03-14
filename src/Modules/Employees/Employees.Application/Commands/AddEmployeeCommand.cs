namespace Employees.Application;

public record AddEmployeeCommand(Employee Employee) : IRequest<Employee>;
