namespace Products.Application;

public record AddProductCommand(Product Product) : IRequest<Product>;
