namespace Employees.Application;

public record DeleteEmployeeCommand(Employee Employee) : IRequest;