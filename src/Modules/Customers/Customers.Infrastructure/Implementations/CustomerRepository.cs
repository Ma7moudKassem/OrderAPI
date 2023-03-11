namespace Customers.Infrastructure;

public class CustomerRepository : BaseRepository<ICustomersDbContext, Customer>, ICustomerRepository
{
    public CustomerRepository(ICustomersDbContext context) : base(context)
    {
    }
}
