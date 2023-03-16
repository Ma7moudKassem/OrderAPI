namespace OrdersDetails.Application;

public class DeleteOrdersDetailByIdCommandHandler : IRequestHandler<DeleteOrdersDetailByIdCommand>
{
    readonly IOrdersDetailUnitOfWork _unitOfWork;
    public DeleteOrdersDetailByIdCommandHandler(IOrdersDetailUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    public async Task<Unit> Handle(DeleteOrdersDetailByIdCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.DeleteAsync(request.Id);

        return Unit.Value;
    }
}