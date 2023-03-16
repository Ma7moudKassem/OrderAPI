namespace OrdersDetails.Application;

public record AddOrdersDetailCommand(OrdersDetail OrdersDetail) : IRequest<OrdersDetail>;
