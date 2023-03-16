namespace Suppliers.Application;

public class AddSupplierCommandHandler : IRequestHandler<AddSupplierCommand, Supplier>
{
    readonly ISupplierUnitOfWork _unitOfWork;
    public AddSupplierCommandHandler(ISupplierUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    public async Task<Supplier> Handle(AddSupplierCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.CreateAsync(request.Supplier);

        return request.Supplier;
    }
}