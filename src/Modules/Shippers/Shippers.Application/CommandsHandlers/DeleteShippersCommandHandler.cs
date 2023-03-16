namespace Shippers.Application;

public class DeleteShippersCommandHandler : IRequestHandler<DeleteShippersCommand>
{
    readonly IShipperUnitOfWork _unitOfWork;
    public DeleteShippersCommandHandler(IShipperUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    public async Task<Unit> Handle(DeleteShippersCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.DeleteAsync(request.Shippers);

        return Unit.Value;
    }
}