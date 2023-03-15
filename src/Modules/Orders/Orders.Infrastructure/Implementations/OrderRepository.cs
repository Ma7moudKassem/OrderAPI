namespace Orders.Infrastructure;

public class OrderRepository : BaseRepository<Order, IOrdersDbContext>, IOrderRepository
{
    public OrderRepository(IOrdersDbContext context) : base(context) { }
}