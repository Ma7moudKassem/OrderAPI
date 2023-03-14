namespace Employees.Application;

public class DeleteEmployeeByIdCommandHandler : IRequestHandler<DeleteEmployeeByIdCommand>
{
    readonly IEmployeeUnitOfWork _unitOfWork;
    public DeleteEmployeeByIdCommandHandler(IEmployeeUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    public async Task<Unit> Handle(DeleteEmployeeByIdCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.DeleteAsync(request.Id);

        return Unit.Value;
    }
}