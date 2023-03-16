namespace OrdersDetails.Application;

public class DeleteOrdersDetailCommandHandler : IRequestHandler<DeleteOrdersDetailCommand>
{
    readonly IOrdersDetailUnitOfWork _unitOfWork;
    public DeleteOrdersDetailCommandHandler(IOrdersDetailUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    public async Task<Unit> Handle(DeleteOrdersDetailCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.DeleteAsync(request.OrdersDetail);

        return Unit.Value;
    }
}