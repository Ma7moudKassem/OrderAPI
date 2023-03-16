namespace Shippers.Application;

public class GetShipperByIdQueryHandler : IRequestHandler<GetShipperByIdQuery, Shipper>
{
    IShipperUnitOfWork _unitOfWork;
    public GetShipperByIdQueryHandler(IShipperUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    public async Task<Shipper> Handle(GetShipperByIdQuery request, CancellationToken cancellationToken) =>
        await _unitOfWork.ReadAsync(request.Id);
}
