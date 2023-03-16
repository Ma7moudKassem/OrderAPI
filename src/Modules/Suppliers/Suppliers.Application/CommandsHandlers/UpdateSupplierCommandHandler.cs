namespace Suppliers.Application;

public class UpdateSupplierCommandHandler : IRequestHandler<UpdateSupplierCommand, Supplier>
{
    readonly ISupplierUnitOfWork _unitOfWork;
    public UpdateSupplierCommandHandler(ISupplierUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    public async Task<Supplier> Handle(UpdateSupplierCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.UpdateAsync(request.Supplier);

        return request.Supplier;
    }
}