namespace Customers.Application;

public record GetCustomerByIdQuery(Guid id) : IRequest<Customer>;