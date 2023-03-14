namespace Customers.Application;

public record DeleteCustomersCommand(IEnumerable<Customer> Customers) : IRequest;