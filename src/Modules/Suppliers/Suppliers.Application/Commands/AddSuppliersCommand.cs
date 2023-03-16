namespace Suppliers.Application;

public record AddSuppliersCommand(IEnumerable<Supplier> Suppliers) : IRequest<IEnumerable<Supplier>>;
