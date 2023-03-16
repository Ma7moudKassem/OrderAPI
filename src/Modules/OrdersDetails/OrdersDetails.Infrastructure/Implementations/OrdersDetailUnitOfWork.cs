namespace OrdersDetails.Infrastructure;

public class OrdersDetailUnitOfWork : BaseUnitOfWork<OrdersDetail, IOrdersDetailsDbContext>, IOrdersDetailUnitOfWork
{
    public OrdersDetailUnitOfWork(IBaseRepository<OrdersDetail, IOrdersDetailsDbContext> repository) : base(repository) { }
}