namespace Shippers.Application;

public record UpdateShippersCommand(IEnumerable<Shipper> Shippers) : IRequest<IEnumerable<Shipper>>;