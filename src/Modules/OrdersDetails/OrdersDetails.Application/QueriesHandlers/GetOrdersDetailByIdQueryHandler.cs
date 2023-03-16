namespace OrdersDetails.Application;

public class GetOrdersDetailByIdQueryHandler : IRequestHandler<GetOrdersDetailByIdQuery, OrdersDetail>
{
    readonly IOrdersDetailUnitOfWork _unitOfWork;
    readonly IOrdersAPI _ordersAPI;
    public GetOrdersDetailByIdQueryHandler(IOrdersDetailUnitOfWork unitOfWork, IOrdersAPI ordersAPI)
    {
        _unitOfWork = unitOfWork;
        _ordersAPI = ordersAPI;
    }

    public async Task<OrdersDetail> Handle(GetOrdersDetailByIdQuery request, CancellationToken cancellationToken)
    {
        OrdersDetail ordersDetail = await _unitOfWork.ReadAsync(request.Id);

        ordersDetail.Order = await _ordersAPI.GetOrderById(ordersDetail.OrderId);

        return ordersDetail;
    }
}