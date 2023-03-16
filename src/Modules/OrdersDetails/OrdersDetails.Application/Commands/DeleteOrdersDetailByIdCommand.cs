namespace OrdersDetails.Application;

public record DeleteOrdersDetailByIdCommand(Guid Id) : IRequest;