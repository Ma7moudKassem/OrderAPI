namespace Customers.Application;

public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
{
    readonly ICustomerUnitOfWork _unitOfWork;
    public DeleteCustomerCommandHandler(ICustomerUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.DeleteAsync(request.Customer);

        return Unit.Value;
    }
}