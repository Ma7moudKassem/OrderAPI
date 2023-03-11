namespace Customers.Application;

public interface ICustomerUnitOfWork : IBaseUnitOfWork<ICustomersDbContext, Customer>
{
}
