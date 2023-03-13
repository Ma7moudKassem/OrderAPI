namespace Customers.Application;

public interface ICustomerRepository
{
    Task<Customer> GetAsync(Guid id);
    Task<IEnumerable<Customer>> GetAsync();
    Task<IEnumerable<Customer>> GetAsync(Expression<Func<Customer, bool>> predicate);

    Task<Customer> AddAsync(Customer customer);
    Task<IEnumerable<Customer>> AddAsync(IEnumerable<Customer> customers);

    Task<Customer> EditAsync(Customer customer);
    Task<IEnumerable<Customer>> EditAsync(IEnumerable<Customer> customers);

    Task RemoveAsync(Guid id);
    Task RemoveAsync(Customer customer);
    Task RemoveAsync(IEnumerable<Customer> customers);

    Task<IDbContextTransaction> BeginTransaction();
}