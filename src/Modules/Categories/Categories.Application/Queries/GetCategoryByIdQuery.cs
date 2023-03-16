namespace Categories.Application;

public record GetCategoryByIdQuery(Guid Id) : IRequest<Category>;