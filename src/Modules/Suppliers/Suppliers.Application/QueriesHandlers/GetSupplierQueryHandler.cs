namespace Suppliers.Application;

public class GetSupplierQueryHandler : IRequestHandler<GetSupplierQuery, IEnumerable<Supplier>>
{
    readonly ISupplierUnitOfWork _unitOfWork;
    public GetSupplierQueryHandler(ISupplierUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    public async Task<IEnumerable<Supplier>> Handle(GetSupplierQuery request, CancellationToken cancellationToken) =>
        await _unitOfWork.ReadAsync();
}