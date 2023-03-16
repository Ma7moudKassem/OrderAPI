namespace Suppliers.Application;

public record DeleteSupplierByIdCommand(Guid Id) : IRequest;