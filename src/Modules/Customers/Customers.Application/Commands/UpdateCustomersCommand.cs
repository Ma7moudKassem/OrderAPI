namespace Customers.Application;

public record UpdateCustomersCommand(IEnumerable<Customer> Customers) : IRequest<IEnumerable<Customer>>;