namespace Customers.Application;

public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Customer>
{
    readonly ICustomerUnitOfWork _unitOfWork;
    public UpdateCustomerCommandHandler(ICustomerUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    public async Task<Customer> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.UpdateAsync(request.Customer);

        return request.Customer;
    }
}