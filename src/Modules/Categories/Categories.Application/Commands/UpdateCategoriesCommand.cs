namespace Categories.Application;

public record UpdateCategoriesCommand(IEnumerable<Category> Categories) : IRequest<IEnumerable<Category>>;