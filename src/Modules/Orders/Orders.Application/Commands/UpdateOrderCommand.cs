namespace Orders.Application;

public record UpdateOrderCommand(Order Order) : IRequest<Order>;