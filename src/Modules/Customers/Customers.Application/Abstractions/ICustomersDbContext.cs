namespace Customers.Application;

public interface ICustomersDbContext
{
    DbSet<Customer> Customers { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    Task<IDbContextTransaction> BeginTransaction();
}