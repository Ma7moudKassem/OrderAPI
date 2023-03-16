namespace Suppliers.Application;

public class UpdateSuppliersCommandHandler : IRequestHandler<UpdateSuppliersCommand, IEnumerable<Supplier>>
{
    readonly ISupplierUnitOfWork _unitOfWork;
    public UpdateSuppliersCommandHandler(ISupplierUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    public async Task<IEnumerable<Supplier>> Handle(UpdateSuppliersCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.UpdateAsync(request.Suppliers);

        return request.Suppliers;
    }
}