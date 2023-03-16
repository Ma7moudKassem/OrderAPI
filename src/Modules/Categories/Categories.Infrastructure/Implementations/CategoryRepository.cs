namespace Categories.Infrastructure;

public class CategoryRepository : BaseRepository<Category, ICategoriesDbContext>, ICategoryRepository
{
    public CategoryRepository(ICategoriesDbContext context) : base(context) { }
}