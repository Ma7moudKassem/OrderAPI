namespace Categories.Application;

public class AddCategoriesCommandHandler : IRequestHandler<AddCategoriesCommand, IEnumerable<Category>>
{
    readonly ICategoryUnitOfWork _unitOfWork;
    public AddCategoriesCommandHandler(ICategoryUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    public async Task<IEnumerable<Category>> Handle(AddCategoriesCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.CreateAsync(request.Categories);

        return request.Categories;
    }
}