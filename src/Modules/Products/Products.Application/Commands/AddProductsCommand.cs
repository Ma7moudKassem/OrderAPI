namespace Products.Application;

public record AddProductsCommand(IEnumerable<Product> Products) : IRequest<IEnumerable<Product>>;
