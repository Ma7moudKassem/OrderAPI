namespace Customers.Application;

public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, Customer>
{
    ICustomerUnitOfWork _unitOfWork;
    public GetCustomerByIdQueryHandler(ICustomerUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;
    
    public async Task<Customer> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken) =>
        await _unitOfWork.ReadAsync(request.Id);
}
