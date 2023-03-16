namespace Categories.Infrastructure;

public class CategoriesDbContext : ModuleDbContext, ICategoriesDbContext
{
    public CategoriesDbContext(DbContextOptions<CategoriesDbContext> options) : base(options) { }

    public DbSet<Category> entities { get; set; }
    protected override string Schema => "Category";

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