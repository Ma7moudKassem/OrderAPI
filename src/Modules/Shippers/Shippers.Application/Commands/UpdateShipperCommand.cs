namespace Shippers.Application;

public record UpdateShipperCommand(Shipper Shipper) : IRequest<Shipper>;