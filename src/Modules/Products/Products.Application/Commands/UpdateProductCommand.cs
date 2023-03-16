namespace Products.Application;

public record UpdateProductCommand(Product Product) : IRequest<Product>;