namespace Orders.Application;

public interface IOrderRepository
{
    Task<Order> GetAsync(Guid id);
    Task<IEnumerable<Order>> GetAsync();
    Task<IEnumerable<Order>> GetAsync(Expression<Func<Order, bool>> predicate);

    Task<Order> AddAsync(Order customer);
    Task<IEnumerable<Order>> AddAsync(IEnumerable<Order> customers);

    Task<Order> EditAsync(Order customer);
    Task<IEnumerable<Order>> EditAsync(IEnumerable<Order> customers);

    Task RemoveAsync(Guid id);
    Task RemoveAsync(Order customer);
    Task RemoveAsync(IEnumerable<Order> customers);

    Task<IDbContextTransaction> BeginTransaction();
}