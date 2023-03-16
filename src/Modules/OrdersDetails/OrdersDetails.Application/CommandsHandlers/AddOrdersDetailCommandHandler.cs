namespace OrdersDetails.Application;

public class AddOrdersDetailCommandHandler : IRequestHandler<AddOrdersDetailCommand, OrdersDetail>
{
    readonly IOrdersDetailUnitOfWork _unitOfWork;
    public AddOrdersDetailCommandHandler(IOrdersDetailUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    public async Task<OrdersDetail> Handle(AddOrdersDetailCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.CreateAsync(request.OrdersDetail);

        return request.OrdersDetail;
    }
}