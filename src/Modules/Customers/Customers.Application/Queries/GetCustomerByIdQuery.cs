namespace Customers.Application;

public record GetCustomerByIdQuery(Guid Id) : IRequest<Customer>;