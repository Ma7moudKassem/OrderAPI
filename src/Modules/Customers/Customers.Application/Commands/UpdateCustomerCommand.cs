namespace Customers.Application;

public record UpdateCustomerCommand(Customer NewCustomer) : IRequest<Customer>;