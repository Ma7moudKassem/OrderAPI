namespace Employees.Application;

public interface IEmployeesDbContext
{
    DbSet<Employee> Employees { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    Task<IDbContextTransaction> BeginTransaction();
}