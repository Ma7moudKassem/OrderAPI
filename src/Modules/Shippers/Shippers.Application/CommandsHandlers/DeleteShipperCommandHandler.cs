namespace Shippers.Application;

public class DeleteShipperCommandHandler : IRequestHandler<DeleteShipperCommand>
{
    readonly IShipperUnitOfWork _unitOfWork;
    public DeleteShipperCommandHandler(IShipperUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    public async Task<Unit> Handle(DeleteShipperCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.DeleteAsync(request.Shipper);

        return Unit.Value;
    }
}