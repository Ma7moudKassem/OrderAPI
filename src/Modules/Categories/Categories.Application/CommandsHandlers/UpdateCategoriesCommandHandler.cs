namespace Categories.Application;

public class UpdateCategoriesCommandHandler : IRequestHandler<UpdateCategoriesCommand, IEnumerable<Category>>
{
    readonly ICategoryUnitOfWork _unitOfWork;
    public UpdateCategoriesCommandHandler(ICategoryUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    public async Task<IEnumerable<Category>> Handle(UpdateCategoriesCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.UpdateAsync(request.Categories);

        return request.Categories;
    }
}