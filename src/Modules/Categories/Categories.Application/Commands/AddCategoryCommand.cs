namespace Categories.Application;

public record AddCategoryCommand(Category Category) : IRequest<Category>;
