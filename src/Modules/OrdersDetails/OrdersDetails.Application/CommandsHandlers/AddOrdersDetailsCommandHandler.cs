namespace OrdersDetails.Application;

public class AddOrdersDetailsCommandHandler : IRequestHandler<AddOrdersDetailsCommand, IEnumerable<OrdersDetail>>
{
    readonly IOrdersDetailUnitOfWork _unitOfWork;
    public AddOrdersDetailsCommandHandler(IOrdersDetailUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    public async Task<IEnumerable<OrdersDetail>> Handle(AddOrdersDetailsCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.CreateAsync(request.OrdersDetails);

        return request.OrdersDetails;
    }
}