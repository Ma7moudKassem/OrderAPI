namespace OrdersDetails.Infrastructure;

public class OrdersDetailsDbContext : ModuleDbContext, IOrdersDetailsDbContext
{
    public OrdersDetailsDbContext(DbContextOptions<OrdersDetailsDbContext> options) : base(options) { }

    public DbSet<OrdersDetail> entities { get; set; }
    protected override string Schema => "OrdersDetail";

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