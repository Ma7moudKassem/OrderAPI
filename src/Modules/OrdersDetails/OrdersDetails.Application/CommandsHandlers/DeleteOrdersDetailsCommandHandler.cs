namespace OrdersDetails.Application;

public class DeleteOrdersDetailsCommandHandler : IRequestHandler<DeleteOrdersDetailsCommand>
{
    readonly IOrdersDetailUnitOfWork _unitOfWork;
    public DeleteOrdersDetailsCommandHandler(IOrdersDetailUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    public async Task<Unit> Handle(DeleteOrdersDetailsCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.DeleteAsync(request.OrdersDetails);

        return Unit.Value;
    }
}