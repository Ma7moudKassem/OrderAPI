namespace Customers.Application;

public record AddCustomerCommand(Customer Customer) : IRequest<Customer>;
