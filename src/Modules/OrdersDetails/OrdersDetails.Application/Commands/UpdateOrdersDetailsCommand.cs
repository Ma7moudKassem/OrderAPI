namespace OrdersDetails.Application;

public record UpdateOrdersDetailsCommand(IEnumerable<OrdersDetail> OrdersDetails) : IRequest<IEnumerable<OrdersDetail>>;