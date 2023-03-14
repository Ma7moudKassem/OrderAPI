namespace Orders.Application;

public class UpdateOrdersCommandHandler : IRequestHandler<UpdateOrdersCommand, IEnumerable<Order>>
{
    readonly IOrderUnitOfWork _unitOfWork;
    public UpdateOrdersCommandHandler(IOrderUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    public async Task<IEnumerable<Order>> Handle(UpdateOrdersCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.UpdateAsync(request.Orders);

        return request.Orders;
    }
}