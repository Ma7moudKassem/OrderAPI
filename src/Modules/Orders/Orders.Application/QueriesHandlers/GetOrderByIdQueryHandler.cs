namespace Orders.Application;

public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, Order>
{
    IOrderUnitOfWork _unitOfWork;
    public GetOrderByIdQueryHandler(IOrderUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    public async Task<Order> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken) =>
        await _unitOfWork.ReadAsync(request.Id);
}
