namespace Products.Application;

public interface IProductUnitOfWork : IBaseUnitOfWork<Product, IProductsDbContext> { }