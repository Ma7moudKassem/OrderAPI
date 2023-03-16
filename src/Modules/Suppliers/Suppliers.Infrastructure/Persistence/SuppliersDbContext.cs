namespace Suppliers.Infrastructure;

public class SuppliersDbContext : ModuleDbContext, ISuppliersDbContext
{
    public SuppliersDbContext(DbContextOptions<SuppliersDbContext> options) : base(options) { }

    public DbSet<Supplier> entities { get; set; }
    protected override string Schema => "Supplier";

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