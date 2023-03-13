namespace Customers.Application;

public interface ICustomerUnitOfWork
{
    Task<Customer> ReadAsync(Guid id);

    Task<IEnumerable<Customer>> ReadAsync();
    Task<IEnumerable<Customer>> ReadAsync(Expression<Func<Customer, bool>> predicate);

    Task<Customer> CreateAsync(Customer customer);
    Task<IEnumerable<Customer>> CreateAsync(IEnumerable<Customer> customers);

    Task<Customer> UpdateAsync(Customer customer);
    Task<IEnumerable<Customer>> UpdateAsync(IEnumerable<Customer> customers);

    Task DeleteAsync(Guid id);
    Task DeleteAsync(Customer customer);
    Task DeleteAsync(IEnumerable<Customer> customers);
}