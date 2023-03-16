namespace Products.Application;

public record DeleteProductCommand(Product Product) : IRequest;