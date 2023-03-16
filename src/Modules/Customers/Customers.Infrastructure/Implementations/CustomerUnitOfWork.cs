namespace Customers.Infrastructure;

public class CustomerUnitOfWork : BaseUnitOfWork<Customer, ICustomersDbContext>, ICustomerUnitOfWork
{
    public CustomerUnitOfWork(ICustomerRepository repository) : base(repository) { }
}