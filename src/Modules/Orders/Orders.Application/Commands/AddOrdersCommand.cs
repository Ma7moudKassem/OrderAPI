namespace Orders.Application;

public record AddOrdersCommand(IEnumerable<Order> Orders) : IRequest<IEnumerable<Order>>;
