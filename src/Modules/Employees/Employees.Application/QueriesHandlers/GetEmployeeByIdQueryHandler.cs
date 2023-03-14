namespace Employees.Application;

public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, Employee>
{
    IEmployeeUnitOfWork _unitOfWork;
    public GetEmployeeByIdQueryHandler(IEmployeeUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    public async Task<Employee> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken) =>
        await _unitOfWork.ReadAsync(request.Id);
}
