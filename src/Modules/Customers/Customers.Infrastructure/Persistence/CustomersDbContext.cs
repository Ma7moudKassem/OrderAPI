namespace Customers.Infrastructure;

public class CustomersDbContext : ModuleDbContext, ICustomersDbContext
{
    public CustomersDbContext(DbContextOptions<CustomersDbContext> options) : base(options) { }

    public DbSet<Customer> Customers { get; set; }
    protected override string Schema => "Customer";

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(GetType().Assembly);

        base.OnModelCreating(builder);
    }

    public async Task<IDbContextTransaction> BeginTransaction()
    {
        if (Database.CurrentTransaction is null)
            return await Database.BeginTransactionAsync();

        return null;
    }
}