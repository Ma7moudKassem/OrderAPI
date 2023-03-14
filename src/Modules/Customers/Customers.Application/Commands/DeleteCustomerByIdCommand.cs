namespace Customers.Application;

public record DeleteCustomerByIdCommand(Guid Id) : IRequest;