namespace Products.Application;

public record DeleteProductsCommand(IEnumerable<Product> Products) : IRequest;