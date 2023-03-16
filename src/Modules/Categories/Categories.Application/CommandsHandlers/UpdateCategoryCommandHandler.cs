namespace Categories.Application;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Category>
{
    readonly ICategoryUnitOfWork _unitOfWork;
    public UpdateCategoryCommandHandler(ICategoryUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    public async Task<Category> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.UpdateAsync(request.Category);

        return request.Category;
    }
}