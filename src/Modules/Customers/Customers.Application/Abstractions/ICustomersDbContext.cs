namespace Customers.Application;

public interface ICustomersDbContext
{
    DbSet<Customer> Customers { get; set; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    
    Task<IDbContextTransaction> BeginTransaction();
}