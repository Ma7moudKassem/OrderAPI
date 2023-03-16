namespace Shippers.Application;

public class UpdateShipperCommandHandler : IRequestHandler<UpdateShipperCommand, Shipper>
{
    readonly IShipperUnitOfWork _unitOfWork;
    public UpdateShipperCommandHandler(IShipperUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    public async Task<Shipper> Handle(UpdateShipperCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.UpdateAsync(request.Shipper);

        return request.Shipper;
    }
}