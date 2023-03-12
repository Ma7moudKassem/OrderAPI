namespace Customers.Infrastructure;

public class CustomerUnitOfWork : ICustomerUnitOfWork
{
    ICustomerRepository _repository;
    public CustomerUnitOfWork(ICustomerRepository repository) => _repository = repository;

    public async Task<Customer> ReadAsync(Guid id) =>
        await _repository.GetAsync(id);

    public async Task<IEnumerable<Customer>> ReadAsync() =>
        await _repository.GetAsync();

    public async Task<IEnumerable<Customer>> ReadAsync(Expression<Func<Customer, bool>> predicate) =>
        await _repository.GetAsync(predicate);
}