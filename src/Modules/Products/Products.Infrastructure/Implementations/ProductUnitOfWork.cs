namespace Products.Infrastructure;

public class ProductUnitOfWork : BaseUnitOfWork<Product, IProductsDbContext>, IProductUnitOfWork
{
    public ProductUnitOfWork(IBaseRepository<Product, IProductsDbContext> repository) : base(repository) { }
}