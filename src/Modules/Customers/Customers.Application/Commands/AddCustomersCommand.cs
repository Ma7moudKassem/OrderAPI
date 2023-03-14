namespace Customers.Application;

public record AddCustomersCommand(IEnumerable<Customer> Customers) : IRequest<IEnumerable<Customer>>;
