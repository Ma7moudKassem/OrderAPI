namespace Customers.Application;

public class DeleteCustomersCommandHandler : IRequestHandler<DeleteCustomersCommand>
{
    readonly ICustomerUnitOfWork _unitOfWork;
    public DeleteCustomersCommandHandler(ICustomerUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    public async Task<Unit> Handle(DeleteCustomersCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.DeleteAsync(request.Customers);

        return Unit.Value;
    }
}