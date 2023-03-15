namespace Orders.Infrastructure;

public class OrdersDbContext : ModuleDbContext, IOrdersDbContext
{
    public OrdersDbContext(DbContextOptions<OrdersDbContext> options) : base(options) { }

    public DbSet<Order> entities { get; set; }
    protected override string Schema => "Order";

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