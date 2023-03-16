namespace OrdersDetails.Application;

public record AddOrdersDetailsCommand(IEnumerable<OrdersDetail> OrdersDetails) : IRequest<IEnumerable<OrdersDetail>>;
