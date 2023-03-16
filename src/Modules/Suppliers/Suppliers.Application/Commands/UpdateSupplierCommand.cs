namespace Suppliers.Application;

public record UpdateSupplierCommand(Supplier Supplier) : IRequest<Supplier>;