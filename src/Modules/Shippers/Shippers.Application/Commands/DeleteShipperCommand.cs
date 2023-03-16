namespace Shippers.Application;

public record DeleteShipperCommand(Shipper Shipper) : IRequest;