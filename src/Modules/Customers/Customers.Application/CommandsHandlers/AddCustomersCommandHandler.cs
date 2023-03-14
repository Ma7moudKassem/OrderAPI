namespace Customers.Application;

public class AddCustomersCommandHandler : IRequestHandler<AddCustomersCommand, IEnumerable<Customer>>
{
    readonly ICustomerUnitOfWork _unitOfWork;
    public AddCustomersCommandHandler(ICustomerUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    public async Task<IEnumerable<Customer>> Handle(AddCustomersCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.CreateAsync(request.Customers);

        return request.Customers;
    }
}