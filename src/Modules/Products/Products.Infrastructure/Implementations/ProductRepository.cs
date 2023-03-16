namespace Products.Infrastructure;

public class ProductRepository : BaseRepository<Product, IProductsDbContext>, IProductRepository
{
    public ProductRepository(IProductsDbContext context) : base(context) { }
}