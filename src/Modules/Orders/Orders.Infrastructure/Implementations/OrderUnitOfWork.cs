namespace Orders.Infrastructure;

public class OrderUnitOfWork : BaseUnitOfWork<Order, IOrdersDbContext>, IOrderUnitOfWork
{
    public OrderUnitOfWork(IOrderRepository repository) : base(repository) { }
}