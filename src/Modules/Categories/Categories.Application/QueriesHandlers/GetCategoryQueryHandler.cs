namespace Categories.Application;

public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, IEnumerable<Category>>
{
    readonly ICategoryUnitOfWork _unitOfWork;
    public GetCategoryQueryHandler(ICategoryUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    public async Task<IEnumerable<Category>> Handle(GetCategoryQuery request, CancellationToken cancellationToken) =>
        await _unitOfWork.ReadAsync();
}