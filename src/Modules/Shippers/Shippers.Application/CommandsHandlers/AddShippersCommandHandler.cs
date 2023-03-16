namespace Shippers.Application;

public class AddShippersCommandHandler : IRequestHandler<AddShippersCommand, IEnumerable<Shipper>>
{
    readonly IShipperUnitOfWork _unitOfWork;
    public AddShippersCommandHandler(IShipperUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    public async Task<IEnumerable<Shipper>> Handle(AddShippersCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.CreateAsync(request.Shippers);

        return request.Shippers;
    }
}