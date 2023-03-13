namespace Customers.Application;

public class AddCustomerCommandHandler : IRequestHandler<AddCustomerCommand, Customer>
{
    ICustomerUnitOfWork _unitOfWork;
    public AddCustomerCommandHandler(ICustomerUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    public Task<Customer> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
    {
        _unitOfWork.
    }
}
