namespace Suppliers.Application;

public class DeleteSupplierCommandHandler : IRequestHandler<DeleteSupplierCommand>
{
    readonly ISupplierUnitOfWork _unitOfWork;
    public DeleteSupplierCommandHandler(ISupplierUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    public async Task<Unit> Handle(DeleteSupplierCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.DeleteAsync(request.Supplier);

        return Unit.Value;
    }
}