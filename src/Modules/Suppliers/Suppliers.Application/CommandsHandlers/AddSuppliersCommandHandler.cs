namespace Suppliers.Application;

public class AddSuppliersCommandHandler : IRequestHandler<AddSuppliersCommand, IEnumerable<Supplier>>
{
    readonly ISupplierUnitOfWork _unitOfWork;
    public AddSuppliersCommandHandler(ISupplierUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    public async Task<IEnumerable<Supplier>> Handle(AddSuppliersCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.CreateAsync(request.Suppliers);

        return request.Suppliers;
    }
}