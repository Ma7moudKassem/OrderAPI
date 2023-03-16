namespace Products.Application;

public record GetProductByIdQuery(Guid Id) : IRequest<Product>;