namespace Customers.Application;

public interface ICustomerUnitOfWork : IBaseUnitOfWork<Customer, ICustomersDbContext> { }