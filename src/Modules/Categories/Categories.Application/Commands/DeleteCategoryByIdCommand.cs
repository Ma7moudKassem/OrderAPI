namespace Categories.Application;

public record DeleteCategoryByIdCommand(Guid Id) : IRequest;