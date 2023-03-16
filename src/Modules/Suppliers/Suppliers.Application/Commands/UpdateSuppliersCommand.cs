namespace Suppliers.Application;

public record UpdateSuppliersCommand(IEnumerable<Supplier> Suppliers) : IRequest<IEnumerable<Supplier>>;