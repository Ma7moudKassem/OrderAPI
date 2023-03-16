namespace Shippers.Application;

public class GetShipperQueryHandler : IRequestHandler<GetShipperQuery, IEnumerable<Shipper>>
{
    readonly IShipperUnitOfWork _unitOfWork;
    public GetShipperQueryHandler(IShipperUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    public async Task<IEnumerable<Shipper>> Handle(GetShipperQuery request, CancellationToken cancellationToken) =>
        await _unitOfWork.ReadAsync();
}