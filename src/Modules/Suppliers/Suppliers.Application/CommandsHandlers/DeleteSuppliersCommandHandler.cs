namespace Suppliers.Application;

public class DeleteSuppliersCommandHandler : IRequestHandler<DeleteSuppliersCommand>
{
    readonly ISupplierUnitOfWork _unitOfWork;
    public DeleteSuppliersCommandHandler(ISupplierUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    public async Task<Unit> Handle(DeleteSuppliersCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.DeleteAsync(request.Suppliers);

        return Unit.Value;
    }
}