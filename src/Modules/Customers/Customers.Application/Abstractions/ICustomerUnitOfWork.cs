namespace Customers.Application;

public interface ICustomerUnitOfWork
{
    Task<Customer> ReadAsync(Guid id);

    Task<IEnumerable<Customer>> ReadAsync();
    Task<IEnumerable<Customer>> ReadAsync(Expression<Func<Customer, bool>> predicate);
}
