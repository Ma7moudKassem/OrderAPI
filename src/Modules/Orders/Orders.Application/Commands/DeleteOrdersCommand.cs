namespace Orders.Application;

public record DeleteOrdersCommand(IEnumerable<Order> Orders) : IRequest;