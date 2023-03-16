namespace Shippers.Application;

public record DeleteShippersCommand(IEnumerable<Shipper> Shippers) : IRequest;