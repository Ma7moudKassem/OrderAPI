namespace OrdersDetails.Application;

public record UpdateOrdersDetailCommand(OrdersDetail OrdersDetail) : IRequest<OrdersDetail>;