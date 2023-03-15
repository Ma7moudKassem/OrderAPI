namespace Customers.Application;

public class DeleteCustomersCommandHandler : IRequestHandler<DeleteCustomersCommand, IEnumerable<Customer>>
{
    readonly ICustomerUnitOfWork _unitOfWork;
    public DeleteCustomersCommandHandler(ICustomerUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    public async Task<IEnumerable<Customer>> Handle(DeleteCustomersCommand request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.DeleteAsync(request.Customers);
    }
}