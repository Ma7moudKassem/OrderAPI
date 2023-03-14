namespace Customers.Application;

public record UpdateCustomerCommand(Customer Customer) : IRequest<Customer>;