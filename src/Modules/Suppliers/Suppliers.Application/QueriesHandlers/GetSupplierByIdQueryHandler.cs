namespace Suppliers.Application;

public class GetSupplierByIdQueryHandler : IRequestHandler<GetSupplierByIdQuery, Supplier>
{
    ISupplierUnitOfWork _unitOfWork;
    public GetSupplierByIdQueryHandler(ISupplierUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    public async Task<Supplier> Handle(GetSupplierByIdQuery request, CancellationToken cancellationToken) =>
        await _unitOfWork.ReadAsync(request.Id);
}
