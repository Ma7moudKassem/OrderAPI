namespace Customers.Application;

public interface ICustomerRepository
{
    Task<Customer> GetAsync(Guid id);
    Task<IEnumerable<Customer>> GetAsync();
    Task<IEnumerable<Customer>> GetAsync(Expression<Func<Customer, bool>> predicate);

    Task<IDbContextTransaction> BeginTransaction();
}