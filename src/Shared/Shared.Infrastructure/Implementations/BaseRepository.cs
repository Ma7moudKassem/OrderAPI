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

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        if (entity is null) throw new ArgumentNullException(typeof(TEntity).Name + "is null");

        await dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();

        return entity;
    }
    public async Task<IEnumerable<TEntity>> AddAsync(IEnumerable<TEntity> entities)
    {
        if (entities is null || !entities.Any())
            throw new ArgumentNullException($"{typeof(TEntity).Name}s are null or empty");

        await dbSet.AddRangeAsync(entities);
        await _context.SaveChangesAsync();

        return entities;
    }

    public async Task<TEntity> EditAsync(TEntity entity)
    {
        await CheckParameterIsExistingInDb(entity);

        await Task.Run(() => dbSet.Update(entity));
        await _context.SaveChangesAsync();

        return entity;
    }
    public async Task<IEnumerable<TEntity>> EditAsync(IEnumerable<TEntity> entities)
    {
        await CheckParameterIsExistingInDb(entities);

        await Task.Run(() => dbSet.UpdateRange(entities));
        await _context.SaveChangesAsync();

        return entities;
    }

    public async Task<TEntity> RemoveAsync(Guid id)
    {
        TEntity entityFromDb = await GetAsync(id);

        await CheckParameterIsExistingInDb(entityFromDb);

        await Task.Run(() => dbSet.Remove(entityFromDb));
        await _context.SaveChangesAsync();

        return entityFromDb;
    }
    public async Task<TEntity> RemoveAsync(TEntity entity)
    {
        await CheckParameterIsExistingInDb(entity);

        await Task.Run(() => dbSet.Remove(entity));
        await _context.SaveChangesAsync();

        return entity;
    }
    public async Task<IEnumerable<TEntity>> RemoveAsync(IEnumerable<TEntity> entities)
    {
        await CheckParameterIsExistingInDb(entities);

        await Task.Run(() => dbSet.RemoveRange(entities));
        await _context.SaveChangesAsync();

        return entities;
    }

    public async Task<IDbContextTransaction> BeginTransaction() =>
        await _context.BeginTransaction();

    private async Task CheckParameterIsExistingInDb(IEnumerable<TEntity> entities)
    {
        IEnumerable<Guid> entitiesIds = entities.Select(e => e.Id);
        IEnumerable<TEntity> entitiesFromDb = await GetAsync(e => entitiesIds.Contains(e.Id));

        if (!entitiesFromDb.Any() || entitiesFromDb.Count() != entities.Count())
            throw new ArgumentNullException($"{typeof(TEntity).Name}s are not found in database");
    }
    private async Task CheckParameterIsExistingInDb(TEntity entity)
    {
        TEntity entityFromDb = await GetAsync(entity.Id);

        if (entityFromDb is null || entityFromDb.Id.Equals(Guid.Empty))
            throw new ArgumentNullException($"{typeof(TEntity).Name} is not found in database");
    }
}