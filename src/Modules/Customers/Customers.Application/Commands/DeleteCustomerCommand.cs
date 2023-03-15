namespace Customers.Application;

public record DeleteCustomerCommand(Customer Customer) : IRequest<Customer>;