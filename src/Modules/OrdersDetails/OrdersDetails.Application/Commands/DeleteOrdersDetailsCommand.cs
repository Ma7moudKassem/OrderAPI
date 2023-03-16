namespace OrdersDetails.Application;

public record DeleteOrdersDetailsCommand(IEnumerable<OrdersDetail> OrdersDetails) : IRequest;