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

    public async Task<IDbContextTransaction> BeginTransaction() =>
        await _context.BeginTransaction();
}
