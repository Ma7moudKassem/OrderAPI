namespace Employees.Application;

public class AddEmployeesCommandHandler : IRequestHandler<AddEmployeesCommand, IEnumerable<Employee>>
{
    readonly IEmployeeUnitOfWork _unitOfWork;
    public AddEmployeesCommandHandler(IEmployeeUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    public async Task<IEnumerable<Employee>> Handle(AddEmployeesCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.CreateAsync(request.Employees);

        return request.Employees;
    }
}