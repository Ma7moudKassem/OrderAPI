namespace Products.Application;

public record UpdateProductsCommand(IEnumerable<Product> Products) : IRequest<IEnumerable<Product>>;