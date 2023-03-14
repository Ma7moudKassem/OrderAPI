namespace Orders.Application;

public class AddOrderCommandHandler : IRequestHandler<AddOrderCommand, Order>
{
    readonly IOrderUnitOfWork _unitOfWork;
    public AddOrderCommandHandler(IOrderUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    public async Task<Order> Handle(AddOrderCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.CreateAsync(request.Order);

        return request.Order;
    }
}