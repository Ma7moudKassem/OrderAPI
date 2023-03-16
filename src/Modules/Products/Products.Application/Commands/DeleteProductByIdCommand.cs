namespace Products.Application;

public record DeleteProductByIdCommand(Guid Id) : IRequest;