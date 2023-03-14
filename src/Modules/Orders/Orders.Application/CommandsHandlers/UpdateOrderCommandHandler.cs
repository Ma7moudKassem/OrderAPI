namespace Orders.Application;

public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, Order>
{
    readonly IOrderUnitOfWork _unitOfWork;
    public UpdateOrderCommandHandler(IOrderUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    public async Task<Order> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.UpdateAsync(request.Order);

        return request.Order;
    }
}