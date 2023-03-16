namespace OrdersDetails.Application;

public record DeleteOrdersDetailCommand(OrdersDetail OrdersDetail) : IRequest;