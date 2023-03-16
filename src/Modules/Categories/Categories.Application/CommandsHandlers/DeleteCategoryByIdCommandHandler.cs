namespace Categories.Application;

public class DeleteCategoryByIdCommandHandler : IRequestHandler<DeleteCategoryByIdCommand>
{
    readonly ICategoryUnitOfWork _unitOfWork;
    public DeleteCategoryByIdCommandHandler(ICategoryUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    public async Task<Unit> Handle(DeleteCategoryByIdCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.DeleteAsync(request.Id);

        return Unit.Value;
    }
}