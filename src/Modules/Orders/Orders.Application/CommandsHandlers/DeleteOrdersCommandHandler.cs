namespace Orders.Application;

public class DeleteOrdersCommandHandler : IRequestHandler<DeleteOrdersCommand>
{
    readonly IOrderUnitOfWork _unitOfWork;
    public DeleteOrdersCommandHandler(IOrderUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    public async Task<Unit> Handle(DeleteOrdersCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.DeleteAsync(request.Orders);

        return Unit.Value;
    }
}