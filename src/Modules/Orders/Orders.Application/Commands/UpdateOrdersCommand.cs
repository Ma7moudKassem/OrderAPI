namespace Orders.Application;

public record UpdateOrdersCommand(IEnumerable<Order> Orders) : IRequest<IEnumerable<Order>>;