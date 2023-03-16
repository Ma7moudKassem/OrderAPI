namespace Shippers.Application;

public record DeleteShipperByIdCommand(Guid Id) : IRequest;