namespace OrdersDetails.Application;

public class UpdateOrdersDetailsCommandHandler : IRequestHandler<UpdateOrdersDetailsCommand, IEnumerable<OrdersDetail>>
{
    readonly IOrdersDetailUnitOfWork _unitOfWork;
    public UpdateOrdersDetailsCommandHandler(IOrdersDetailUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    public async Task<IEnumerable<OrdersDetail>> Handle(UpdateOrdersDetailsCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.UpdateAsync(request.OrdersDetails);

        return request.OrdersDetails;
    }
}