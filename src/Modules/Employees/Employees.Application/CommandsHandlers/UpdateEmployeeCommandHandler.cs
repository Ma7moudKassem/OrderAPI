namespace Employees.Application;

public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, Employee>
{
    readonly IEmployeeUnitOfWork _unitOfWork;
    public UpdateEmployeeCommandHandler(IEmployeeUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    public async Task<Employee> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.UpdateAsync(request.Employee);

        return request.Employee;
    }
}