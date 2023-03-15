namespace Orders.Application;

public class AddOrderCommandHandler : IRequestHandler<AddOrderCommand, Order>
{
    readonly IOrderUnitOfWork _unitOfWork;
    readonly ICustomerAPI _customerAPI;
    public AddOrderCommandHandler(IOrderUnitOfWork unitOfWork, ICustomerAPI customerAPI)
    {
        _unitOfWork = unitOfWork;
        _customerAPI = customerAPI;
    }

    public async Task<Order> Handle(AddOrderCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.CreateAsync(request.Order);

        request.Order.Customer = await _customerAPI.GetCustomer(request.Order.CustomerId);

        return request.Order;
    }
}