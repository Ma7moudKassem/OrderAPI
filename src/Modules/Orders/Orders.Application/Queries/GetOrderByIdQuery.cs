namespace Orders.Application;

public record GetOrderByIdQuery(Guid Id) : IRequest<Order>;