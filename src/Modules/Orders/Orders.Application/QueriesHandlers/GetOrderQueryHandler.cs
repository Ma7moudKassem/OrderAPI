namespace Orders.Application;

public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, IEnumerable<Order>>
{
    readonly IOrderUnitOfWork _unitOfWork;
    public GetOrderQueryHandler(IOrderUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    public async Task<IEnumerable<Order>> Handle(GetOrderQuery request, CancellationToken cancellationToken) =>
        await _unitOfWork.ReadAsync();
}