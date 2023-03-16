namespace Categories.Application;

public record GetCategoryQuery() : IRequest<IEnumerable<Category>>;
