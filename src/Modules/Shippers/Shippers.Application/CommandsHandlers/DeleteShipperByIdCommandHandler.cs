namespace Shippers.Application;

public class DeleteShipperByIdCommandHandler : IRequestHandler<DeleteShipperByIdCommand>
{
    readonly IShipperUnitOfWork _unitOfWork;
    public DeleteShipperByIdCommandHandler(IShipperUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    public async Task<Unit> Handle(DeleteShipperByIdCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.DeleteAsync(request.Id);

        return Unit.Value;
    }
}