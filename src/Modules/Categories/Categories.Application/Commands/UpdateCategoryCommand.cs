namespace Categories.Application;

public record UpdateCategoryCommand(Category Category) : IRequest<Category>;