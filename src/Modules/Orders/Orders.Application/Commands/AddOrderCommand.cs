namespace Orders.Application;

public record AddOrderCommand(Order Order) : IRequest<Order>;
