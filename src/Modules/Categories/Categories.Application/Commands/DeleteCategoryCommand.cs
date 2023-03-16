namespace Categories.Application;

public record DeleteCategoryCommand(Category Category) : IRequest;