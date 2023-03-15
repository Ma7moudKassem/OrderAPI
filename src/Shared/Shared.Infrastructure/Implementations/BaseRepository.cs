namespace Shared.Infrastructure;

public class BaseRepository<TEntity, TContext> : IBaseRepository<TEntity, TContext> where TEntity : BaseEntity where TContext : IModuleDbContext<TEntity>
{
    readonly TContext _context;
    readonly DbSet<TEntity> dbSet;
    public BaseRepository(TContext context)
    {
        _context = context;
        dbSet = _context.entities;
    }

    public async Task<TEntity> GetAsync(Guid id) =>
    await dbSet.FirstOrDefaultAsync(e => e.Id == id) ?? Activator.CreateInstance<TEntity>();
    public async Task<IEnumerable<TEntity>> GetAsync() =>
        await dbSet.ToListAsync();
    public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate) =>
        await dbSet.Where(predicate).ToListAsync();

    public async Task<TEntity> AddAsync(TEntity TEntity)
    {
        if (TEntity is null) throw new ArgumentNullException(nameof(TEntity) + "is null");

        await dbSet.AddAsync(TEntity);
        await _context.SaveChangesAsync();

        return TEntity;
    }
    public async Task<IEnumerable<TEntity>> AddAsync(IEnumerable<TEntity> TEntitys)
    {
        if (TEntitys is null || !TEntitys.Any())
            throw new ArgumentNullException($"{typeof(TEntity).Name}s are null or empty");

        await dbSet.AddRangeAsync(TEntitys);
        await _context.SaveChangesAsync();

        return TEntitys;
    }

    public async Task<TEntity> EditAsync(TEntity TEntity)
    {
        await CheckParameterIsExistingInDb(TEntity);

        await Task.Run(() => dbSet.Update(TEntity));
        await _context.SaveChangesAsync();

        return TEntity;
    }
    public async Task<IEnumerable<TEntity>> EditAsync(IEnumerable<TEntity> TEntitys)
    {
        await CheckParameterIsExistingInDb(TEntitys);

        await Task.Run(() => dbSet.UpdateRange(TEntitys));
        await _context.SaveChangesAsync();

        return TEntitys;
    }

    public async Task RemoveAsync(Guid id)
    {
        TEntity TEntityFromDb = await GetAsync(id);

        await CheckParameterIsExistingInDb(TEntityFromDb);

        await Task.Run(() => dbSet.Remove(TEntityFromDb));
        await _context.SaveChangesAsync();
    }
    public async Task RemoveAsync(TEntity TEntity)
    {
        await CheckParameterIsExistingInDb(TEntity);

        await Task.Run(() => dbSet.Remove(TEntity));
        await _context.SaveChangesAsync();
    }
    public async Task RemoveAsync(IEnumerable<TEntity> TEntitys)
    {
        await CheckParameterIsExistingInDb(TEntitys);

        await Task.Run(() => dbSet.RemoveRange(TEntitys));
        await _context.SaveChangesAsync();
    }

    public async Task<IDbContextTransaction> BeginTransaction() =>
        await _context.BeginTransaction();

    private async Task CheckParameterIsExistingInDb(IEnumerable<TEntity> TEntitys)
    {
        IEnumerable<Guid> TEntitysIds = TEntitys.Select(e => e.Id);
        IEnumerable<TEntity> TEntitysFromDb = await GetAsync(e => TEntitysIds.Contains(e.Id));

        if (!TEntitysFromDb.Any() || TEntitysFromDb.Count() != TEntitys.Count())
            throw new ArgumentNullException($"{typeof(TEntity).Name}s are not found in database");
    }
    private async Task CheckParameterIsExistingInDb(TEntity TEntity)
    {
        TEntity TEntityFromDb = await GetAsync(TEntity.Id);

        if (TEntityFromDb is null || TEntityFromDb.Id.Equals(Guid.Empty))
            throw new ArgumentNullException($"{typeof(TEntity).Name} is not found in database");
    }
}