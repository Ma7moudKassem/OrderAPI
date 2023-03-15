namespace Orders.Application;

public interface IOrderUnitOfWork : IBaseUnitOfWork<Order, IOrdersDbContext> { }