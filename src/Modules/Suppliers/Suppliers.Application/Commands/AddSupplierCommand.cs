namespace Suppliers.Application;

public record AddSupplierCommand(Supplier Supplier) : IRequest<Supplier>;
