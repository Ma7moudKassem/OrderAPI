namespace Categories.Application;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
{
    readonly ICategoryUnitOfWork _unitOfWork;
    public DeleteCategoryCommandHandler(ICategoryUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.DeleteAsync(request.Category);

        return Unit.Value;
    }
}