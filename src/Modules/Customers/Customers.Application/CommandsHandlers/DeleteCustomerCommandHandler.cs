namespace Customers.Application;

public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, Customer>
{
    readonly ICustomerUnitOfWork _unitOfWork;
    public DeleteCustomerCommandHandler(ICustomerUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    public async Task<Customer> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.DeleteAsync(request.Customer);
    }
}