namespace OrdersDetails.Application;

public record GetOrdersDetailQuery() : IRequest<IEnumerable<OrdersDetail>>;
