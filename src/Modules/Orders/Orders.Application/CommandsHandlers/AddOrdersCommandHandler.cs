namespace Orders.Application;

public class AddOrdersCommandHandler : IRequestHandler<AddOrdersCommand, IEnumerable<Order>>
{
    readonly IOrderUnitOfWork _unitOfWork;
    public AddOrdersCommandHandler(IOrderUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    public async Task<IEnumerable<Order>> Handle(AddOrdersCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.CreateAsync(request.Orders);

        return request.Orders;
    }
}