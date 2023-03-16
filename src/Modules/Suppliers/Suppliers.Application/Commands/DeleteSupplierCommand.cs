namespace Suppliers.Application;

public record DeleteSupplierCommand(Supplier Supplier) : IRequest;