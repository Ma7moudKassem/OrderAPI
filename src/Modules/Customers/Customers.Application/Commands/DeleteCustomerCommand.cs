namespace Customers.Application;

public record DeleteCustomerCommand(Guid Id) : IRequest;