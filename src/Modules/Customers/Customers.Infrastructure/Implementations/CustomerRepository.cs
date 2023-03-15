namespace Customers.Infrastructure;

public class CustomerRepository : BaseRepository<Customer, ICustomersDbContext>, ICustomerRepository
{
    public CustomerRepository(ICustomersDbContext context) : base(context)
    {
    }
}