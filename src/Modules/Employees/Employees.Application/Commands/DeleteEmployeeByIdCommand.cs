namespace Employees.Application;

public record DeleteEmployeeByIdCommand(Guid Id) : IRequest;