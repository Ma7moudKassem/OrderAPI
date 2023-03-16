namespace Categories.Application;

public record DeleteCategoriesCommand(IEnumerable<Category> Categories) : IRequest;