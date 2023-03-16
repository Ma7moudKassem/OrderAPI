namespace Products.Application;

public record GetProductQuery() : IRequest<IEnumerable<Product>>;
