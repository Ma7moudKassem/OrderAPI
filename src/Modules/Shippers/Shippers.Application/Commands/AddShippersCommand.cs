namespace Shippers.Application;

public record AddShippersCommand(IEnumerable<Shipper> Shippers) : IRequest<IEnumerable<Shipper>>;
