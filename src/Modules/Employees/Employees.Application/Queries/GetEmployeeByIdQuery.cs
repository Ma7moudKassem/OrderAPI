namespace Employees.Application;

public record GetEmployeeByIdQuery(Guid Id) : IRequest<Employee>;