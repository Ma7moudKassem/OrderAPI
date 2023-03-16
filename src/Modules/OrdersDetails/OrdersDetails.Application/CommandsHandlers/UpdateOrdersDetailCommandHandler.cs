namespace OrdersDetails.Application;

public class UpdateOrdersDetailCommandHandler : IRequestHandler<UpdateOrdersDetailCommand, OrdersDetail>
{
    readonly IOrdersDetailUnitOfWork _unitOfWork;
    public UpdateOrdersDetailCommandHandler(IOrdersDetailUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    public async Task<OrdersDetail> Handle(UpdateOrdersDetailCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.UpdateAsync(request.OrdersDetail);

        return request.OrdersDetail;
    }
}