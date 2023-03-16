namespace Suppliers.Application;

public record GetSupplierQuery() : IRequest<IEnumerable<Supplier>>;
