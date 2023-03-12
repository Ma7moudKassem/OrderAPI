namespace Customers.Application;

public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, IEnumerable<Customer>>
{
    readonly ICustomerUnitOfWork _unitOfWork;
    public GetCustomerQueryHandler(ICustomerUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    public async Task<IEnumerable<Customer>> Handle(GetCustomerQuery request, CancellationToken cancellationToken) =>
        await _unitOfWork.ReadAsync();
}