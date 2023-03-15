namespace Customers.Application;

public interface ICustomerRepository : IBaseRepository<Customer, ICustomersDbContext> { }