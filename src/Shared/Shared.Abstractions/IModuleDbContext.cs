using Microsoft.EntityFrameworkCore;

namespace Shared.Abstractions;

public interface IModuleDbContext<TEntity> where TEntity : BaseEntity
{
    public string Schema { get; }
    public DbSet<TEntity> dbSet { get; set; }
}
