namespace Employees.Application;

public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand>
{
    readonly IEmployeeUnitOfWork _unitOfWork;
    public DeleteEmployeeCommandHandler(IEmployeeUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.DeleteAsync(request.Employee);

        return Unit.Value;
    }
}