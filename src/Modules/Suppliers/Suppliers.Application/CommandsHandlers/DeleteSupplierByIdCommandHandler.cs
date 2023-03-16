namespace Suppliers.Application;

public class DeleteSupplierByIdCommandHandler : IRequestHandler<DeleteSupplierByIdCommand>
{
    readonly ISupplierUnitOfWork _unitOfWork;
    public DeleteSupplierByIdCommandHandler(ISupplierUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    public async Task<Unit> Handle(DeleteSupplierByIdCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.DeleteAsync(request.Id);

        return Unit.Value;
    }
}