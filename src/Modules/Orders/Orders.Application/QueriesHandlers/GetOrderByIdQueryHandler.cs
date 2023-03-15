namespace Orders.Application;

public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, Order>
{
    IOrderUnitOfWork _unitOfWork;
    IEmployeeAPI _employeeAPI;
    ICustomerAPI _customerAPI;
    public GetOrderByIdQueryHandler(
        IOrderUnitOfWork unitOfWork,
        IEmployeeAPI employeeAPI,
        ICustomerAPI customerAPI)
    {
        _unitOfWork = unitOfWork;
        _employeeAPI = employeeAPI;
        _customerAPI = customerAPI;
    }

    public async Task<Order> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        Order order = await _unitOfWork.ReadAsync(request.Id);

        order.Employee = await _employeeAPI.GetEmployee(order.EmployeeId);
        order.Customer = await _customerAPI.GetCustomer(order.CustomerId);

        return order;
    }
}