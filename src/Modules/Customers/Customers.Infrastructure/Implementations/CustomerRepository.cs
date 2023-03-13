namespace Customers.Infrastructure;

public class CustomerRepository : ICustomerRepository
{
    readonly ICustomersDbContext _context;
    public CustomerRepository(ICustomersDbContext context)
        => _context = context;

    public async Task<Customer> GetAsync(Guid id) =>
        await _context.Customers.FirstOrDefaultAsync(e => e.Id == id) ?? new();
    public async Task<IEnumerable<Customer>> GetAsync() =>
        await _context.Customers.ToListAsync();
    public async Task<IEnumerable<Customer>> GetAsync(Expression<Func<Customer, bool>> predicate) =>
        await _context.Customers.Where(predicate).ToListAsync();
   
    public async Task<Customer> AddAsync(Customer customer)
    {
        if (customer is null) throw new ArgumentNullException(nameof(customer) + "is null");

        await _context.Customers.AddAsync(customer);
        await _context.SaveChangesAsync();

        return customer;
    }
    public async Task<IEnumerable<Customer>> AddAsync(IEnumerable<Customer> customers)
    {
        if (customers is null || !customers.Any())
            throw new ArgumentNullException($"{typeof(Customer).Name}s are null or empty");

        await _context.Customers.AddRangeAsync(customers);
        await _context.SaveChangesAsync();

        return customers;
    }

    public async Task<Customer> EditAsync(Customer customer)
    {
        await CheckParameterIsExistingInDb(customer);

        await Task.Run(() => _context.Customers.Update(customer));
        await _context.SaveChangesAsync();

        return customer;
    }
    public async Task<IEnumerable<Customer>> EditAsync(IEnumerable<Customer> customers)
    {
        await CheckParameterIsExistingInDb(customers);

        await Task.Run(() => _context.Customers.UpdateRange(customers));
        await _context.SaveChangesAsync();

        return customers;
    }

    public async Task RemoveAsync(Guid id)
    {
        Customer customerFromDb = await GetAsync(id);
        
        await CheckParameterIsExistingInDb(customerFromDb);

        await Task.Run(() => _context.Customers.Remove(customerFromDb));
        await _context.SaveChangesAsync();
    }
    public async Task RemoveAsync(Customer customer)
    {
        await CheckParameterIsExistingInDb(customer);

        await Task.Run(() => _context.Customers.Remove(customer));
        await _context.SaveChangesAsync();
    }
    public async Task RemoveAsync(IEnumerable<Customer> customers)
    {
        await CheckParameterIsExistingInDb(customers);

        await Task.Run(() => _context.Customers.RemoveRange(customers));
        await _context.SaveChangesAsync();
    }

    public async Task<IDbContextTransaction> BeginTransaction() =>
        await _context.BeginTransaction();
    
    private async Task CheckParameterIsExistingInDb(IEnumerable<Customer> customers)
    {
        IEnumerable<Guid> customersIds = customers.Select(e => e.Id);
        IEnumerable<Customer> customersFromDb = await GetAsync(e => customersIds.Contains(e.Id));

        if (!customersFromDb.Any() || customersFromDb.Count() != customers.Count())
            throw new ArgumentNullException($"{typeof(Customer).Name}s are not found in database");
    }
    private async Task CheckParameterIsExistingInDb(Customer customer)
    {
        Customer customerFromDb = await GetAsync(customer.Id);

        if (customerFromDb is null || customerFromDb.Id.Equals(Guid.Empty))
            throw new ArgumentNullException($"{typeof(Customer).Name} is not found in database");
    }
}
