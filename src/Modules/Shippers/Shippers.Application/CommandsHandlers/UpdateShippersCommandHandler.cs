namespace Shippers.Application;

public class UpdateShippersCommandHandler : IRequestHandler<UpdateShippersCommand, IEnumerable<Shipper>>
{
    readonly IShipperUnitOfWork _unitOfWork;
    public UpdateShippersCommandHandler(IShipperUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    public async Task<IEnumerable<Shipper>> Handle(UpdateShippersCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.UpdateAsync(request.Shippers);

        return request.Shippers;
    }
}