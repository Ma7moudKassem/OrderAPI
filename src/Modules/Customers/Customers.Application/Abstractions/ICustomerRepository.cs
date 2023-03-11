namespace Customers.Application;

public interface ICustomerRepository : IBaseRepository<ICustomersDbContext, Customer>
{
}