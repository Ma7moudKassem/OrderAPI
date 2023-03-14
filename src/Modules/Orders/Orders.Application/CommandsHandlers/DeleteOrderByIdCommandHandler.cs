namespace Orders.Application;

public class DeleteOrderByIdCommandHandler : IRequestHandler<DeleteOrderByIdCommand>
{
    readonly IOrderUnitOfWork _unitOfWork;
    public DeleteOrderByIdCommandHandler(IOrderUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    public async Task<Unit> Handle(DeleteOrderByIdCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.DeleteAsync(request.Id);

        return Unit.Value;
    }
}