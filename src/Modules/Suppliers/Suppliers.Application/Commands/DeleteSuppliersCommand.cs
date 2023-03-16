namespace Suppliers.Application;

public record DeleteSuppliersCommand(IEnumerable<Supplier> Suppliers) : IRequest;