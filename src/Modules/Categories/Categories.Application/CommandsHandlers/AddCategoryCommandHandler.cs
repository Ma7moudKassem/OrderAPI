namespace Categories.Application;

public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommand, Category>
{
    readonly ICategoryUnitOfWork _unitOfWork;
    public AddCategoryCommandHandler(ICategoryUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    public async Task<Category> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.CreateAsync(request.Category);

        return request.Category;
    }
}