namespace Shippers.Application;

public record GetShipperByIdQuery(Guid Id) : IRequest<Shipper>;