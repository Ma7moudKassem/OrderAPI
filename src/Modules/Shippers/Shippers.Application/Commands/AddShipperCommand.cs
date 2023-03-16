namespace Shippers.Application;

public record AddShipperCommand(Shipper Shipper) : IRequest<Shipper>;
