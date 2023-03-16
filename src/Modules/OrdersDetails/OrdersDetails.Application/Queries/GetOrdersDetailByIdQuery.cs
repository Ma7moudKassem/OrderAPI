namespace OrdersDetails.Application;

public record GetOrdersDetailByIdQuery(Guid Id) : IRequest<OrdersDetail>;