namespace Orders.Application;

public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
{
    readonly IOrderUnitOfWork _unitOfWork;
    public DeleteOrderCommandHandler(IOrderUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.DeleteAsync(request.Order);

        return Unit.Value;
    }
}