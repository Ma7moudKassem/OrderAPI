namespace Employees.Application;

public class AddEmployeeCommandHandler : IRequestHandler<AddEmployeeCommand, Employee>
{
    readonly IEmployeeUnitOfWork _unitOfWork;
    public AddEmployeeCommandHandler(IEmployeeUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    public async Task<Employee> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.CreateAsync(request.Employee);

        return request.Employee;
    }
}