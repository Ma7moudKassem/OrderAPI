namespace Customers.Infrastructure;

public class CustomerUnitOfWork : BaseUnitOfWork<ICustomersDbContext, Customer>, ICustomerUnitOfWork
{
    public CustomerUnitOfWork(BaseGetRepository<ICustomersDbContext, Customer> repository) : base(repository)
    {
    }
}
