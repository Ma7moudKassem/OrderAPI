namespace Customers.Application;

public class DeleteCustomerByIdCommandHandler : IRequestHandler<DeleteCustomerByIdCommand, Customer>
{
    readonly ICustomerUnitOfWork _unitOfWork;
    public DeleteCustomerByIdCommandHandler(ICustomerUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    public async Task<Customer> Handle(DeleteCustomerByIdCommand request, CancellationToken cancellationToken)
    {
        Customer customer = await _unitOfWork.DeleteAsync(request.Id);
       
        return customer;
    }
}