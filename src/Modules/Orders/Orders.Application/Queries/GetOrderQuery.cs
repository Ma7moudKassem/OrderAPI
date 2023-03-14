namespace Orders.Application;

public record GetOrderQuery() : IRequest<IEnumerable<Order>>;
