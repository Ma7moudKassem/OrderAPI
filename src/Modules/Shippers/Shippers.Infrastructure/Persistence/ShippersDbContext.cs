namespace Shippers.Infrastructure;

public class ShippersDbContext : ModuleDbContext, IShippersDbContext
{
    public ShippersDbContext(DbContextOptions<ShippersDbContext> options) : base(options) { }

    public DbSet<Shipper> entities { get; set; }
    protected override string Schema => "Shipper";

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