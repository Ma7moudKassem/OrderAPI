namespace Customers.Application;

public class UpdateCustomersCommandHandler : IRequestHandler<UpdateCustomersCommand, IEnumerable<Customer>>
{
    readonly ICustomerUnitOfWork _unitOfWork;
    public UpdateCustomersCommandHandler(ICustomerUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    public async Task<IEnumerable<Customer>> Handle(UpdateCustomersCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.UpdateAsync(request.Customers);

        return request.Customers;
    }
}