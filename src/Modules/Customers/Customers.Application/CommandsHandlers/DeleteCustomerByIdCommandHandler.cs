namespace Customers.Application;

public class DeleteCustomerByIdCommandHandler : IRequestHandler<DeleteCustomerByIdCommand>
{
    readonly ICustomerUnitOfWork _unitOfWork;
    public DeleteCustomerByIdCommandHandler(ICustomerUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    public async Task<Unit> Handle(DeleteCustomerByIdCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.DeleteAsync(request.Id);

        return Unit.Value;
    }
}