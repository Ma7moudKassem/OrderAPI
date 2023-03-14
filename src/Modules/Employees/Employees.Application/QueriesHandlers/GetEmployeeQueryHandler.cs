namespace Employees.Application;

public class GetEmployeeQueryHandler : IRequestHandler<GetEmployeeQuery, IEnumerable<Employee>>
{
    readonly IEmployeeUnitOfWork _unitOfWork;
    public GetEmployeeQueryHandler(IEmployeeUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    public async Task<IEnumerable<Employee>> Handle(GetEmployeeQuery request, CancellationToken cancellationToken) =>
        await _unitOfWork.ReadAsync();
}