namespace Employees.Application;

public class UpdateEmployeesCommandHandler : IRequestHandler<UpdateEmployeesCommand, IEnumerable<Employee>>
{
    readonly IEmployeeUnitOfWork _unitOfWork;
    public UpdateEmployeesCommandHandler(IEmployeeUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    public async Task<IEnumerable<Employee>> Handle(UpdateEmployeesCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.UpdateAsync(request.Employees);

        return request.Employees;
    }
}