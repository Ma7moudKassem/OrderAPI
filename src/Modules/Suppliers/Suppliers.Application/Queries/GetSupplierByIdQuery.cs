namespace Suppliers.Application;

public record GetSupplierByIdQuery(Guid Id) : IRequest<Supplier>;