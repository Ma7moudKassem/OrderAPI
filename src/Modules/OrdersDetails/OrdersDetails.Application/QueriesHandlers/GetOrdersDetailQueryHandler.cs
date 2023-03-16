namespace OrdersDetails.Application;

public class GetOrdersDetailQueryHandler : IRequestHandler<GetOrdersDetailQuery, IEnumerable<OrdersDetail>>
{
    readonly IOrdersDetailUnitOfWork _unitOfWork;
    public GetOrdersDetailQueryHandler(IOrdersDetailUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    public async Task<IEnumerable<OrdersDetail>> Handle(GetOrdersDetailQuery request, CancellationToken cancellationToken) =>
        await _unitOfWork.ReadAsync();
}