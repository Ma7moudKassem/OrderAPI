namespace Orders.Application;

public record DeleteOrderCommand(Order Order) : IRequest;