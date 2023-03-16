namespace Categories.Application;

public record AddCategoriesCommand(IEnumerable<Category> Categories) : IRequest<IEnumerable<Category>>;
