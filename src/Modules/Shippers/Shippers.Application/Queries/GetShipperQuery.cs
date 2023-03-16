namespace Shippers.Application;

public record GetShipperQuery() : IRequest<IEnumerable<Shipper>>;
