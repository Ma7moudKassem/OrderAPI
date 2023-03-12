namespace Customers.Application;

public record GetCustomerQuery() : IRequest<IEnumerable<Customer>>;
