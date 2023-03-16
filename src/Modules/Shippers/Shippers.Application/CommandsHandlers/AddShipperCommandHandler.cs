namespace Shippers.Application;

public class AddShipperCommandHandler : IRequestHandler<AddShipperCommand, Shipper>
{
    readonly IShipperUnitOfWork _unitOfWork;
    public AddShipperCommandHandler(IShipperUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    public async Task<Shipper> Handle(AddShipperCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.CreateAsync(request.Shipper);

        return request.Shipper;
    }
}