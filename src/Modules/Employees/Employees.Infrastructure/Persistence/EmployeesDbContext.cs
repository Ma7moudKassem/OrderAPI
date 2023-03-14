namespace Employees.Infrastructure;

public class EmployeesDbContext : ModuleDbContext, IEmployeesDbContext
{
    public EmployeesDbContext(DbContextOptions<EmployeesDbContext> options) : base(options) { }

    public DbSet<Employee> Employees { get; set; }
    protected override string Schema => "Employee";

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