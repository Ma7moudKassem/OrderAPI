namespace OrdersDetails.Infrastructure;

public class OrdersDetailRepository : BaseRepository<OrdersDetail, IOrdersDetailsDbContext>, IOrdersDetailRepository
{
    public OrdersDetailRepository(IOrdersDetailsDbContext context) : base(context) { }
}