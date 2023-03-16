namespace Categories.Application;

public class DeleteCategoriesCommandHandler : IRequestHandler<DeleteCategoriesCommand>
{
    readonly ICategoryUnitOfWork _unitOfWork;
    public DeleteCategoriesCommandHandler(ICategoryUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    public async Task<Unit> Handle(DeleteCategoriesCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.DeleteAsync(request.Categories);

        return Unit.Value;
    }
}