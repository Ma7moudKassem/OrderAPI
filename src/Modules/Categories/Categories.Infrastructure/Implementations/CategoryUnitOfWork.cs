namespace Categories.Infrastructure;

public class CategoryUnitOfWork : BaseUnitOfWork<Category, ICategoriesDbContext>, ICategoryUnitOfWork
{
    public CategoryUnitOfWork(IBaseRepository<Category, ICategoriesDbContext> repository) : base(repository) { }
}