namespace Customers.Infrastructure;

public class CustomerRepository : BaseRepository<CustomersDbContext, Customer>, ICustomerRepository
{
    public CustomerRepository(CustomersDbContext context) : base(context) { }
}
