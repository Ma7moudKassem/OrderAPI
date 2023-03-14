namespace Customers.Application;

public class AddCustomerCommandHandler : IRequestHandler<AddCustomerCommand, Customer>
{
    readonly ICustomerUnitOfWork _unitOfWork;
    public AddCustomerCommandHandler(ICustomerUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    public async Task<Customer> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.CreateAsync(request.Customer);

        return request.Customer;
    }
}