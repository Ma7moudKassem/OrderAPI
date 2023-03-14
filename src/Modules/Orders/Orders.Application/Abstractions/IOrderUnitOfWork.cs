namespace Orders.Application;

public interface IOrderUnitOfWork
{
    Task<Order> ReadAsync(Guid id);

    Task<IEnumerable<Order>> ReadAsync();
    Task<IEnumerable<Order>> ReadAsync(Expression<Func<Order, bool>> predicate);

    Task<Order> CreateAsync(Order customer);
    Task<IEnumerable<Order>> CreateAsync(IEnumerable<Order> customers);

    Task<Order> UpdateAsync(Order customer);
    Task<IEnumerable<Order>> UpdateAsync(IEnumerable<Order> customers);

    Task DeleteAsync(Guid id);
    Task DeleteAsync(Order customer);
    Task DeleteAsync(IEnumerable<Order> customers);
}