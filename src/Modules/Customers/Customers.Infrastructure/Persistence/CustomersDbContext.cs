namespace Customers.Infrastructure;

public class CustomersDbContext : ModuleDbContext<Customer> , ICustomersDbContext
{
    public CustomersDbContext(DbContextOptions<CustomersDbContext> options) : base(options) { }

    protected override string Schema => "Customer";

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(GetType().Assembly);

        base.OnModelCreating(builder);
    }
}
