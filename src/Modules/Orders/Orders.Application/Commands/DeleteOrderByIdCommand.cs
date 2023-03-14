namespace Orders.Application;

public record DeleteOrderByIdCommand(Guid Id) : IRequest;