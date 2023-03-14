namespace Employees.Application;

public class DeleteEmployeesCommandHandler : IRequestHandler<DeleteEmployeesCommand>
{
    readonly IEmployeeUnitOfWork _unitOfWork;
    public DeleteEmployeesCommandHandler(IEmployeeUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    public async Task<Unit> Handle(DeleteEmployeesCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.DeleteAsync(request.Employees);

        return Unit.Value;
    }
}