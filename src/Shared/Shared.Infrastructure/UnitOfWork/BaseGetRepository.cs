namespace Shared.Infrastructure;

public class BaseGetRepository<TContext, TEntity> : IBaseGetRepository<TEntity>
    where TContext : ModuleDbContext where TEntity : BaseEntity
{

    protected DbSet<TEntity> dbSet;
    private readonly TContext _context;
    public BaseGetRepository(TContext context)
    {
        _context = context;
        dbSet = _context.Set<TEntity>();
    }

    public virtual async Task<TEntity> GetAsync(Guid id)
        => await dbSet.FirstOrDefaultAsync(e => e.Id == id) ?? Activator.CreateInstance<TEntity>();

    public virtual async Task<IEnumerable<TEntity>> GetAsync()
        => await dbSet.ToListAsync();

    public virtual async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate)
        => await dbSet.Where(predicate).ToListAsync();
}
