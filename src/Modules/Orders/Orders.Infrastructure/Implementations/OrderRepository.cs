namespace Orders.Infrastructure;

public class OrderRepository : IOrderRepository
{
    readonly IOrdersDbContext _context;
    public OrderRepository(IOrdersDbContext context)
        => _context = context;

    public async Task<Order> GetAsync(Guid id) =>
        await _context.Orders.FirstOrDefaultAsync(e => e.Id == id) ?? new();
    public async Task<IEnumerable<Order>> GetAsync() =>
        await _context.Orders.ToListAsync();
    public async Task<IEnumerable<Order>> GetAsync(Expression<Func<Order, bool>> predicate) =>
        await _context.Orders.Where(predicate).ToListAsync();
   
    public async Task<Order> AddAsync(Order order)
    {
        if (order is null) throw new ArgumentNullException(nameof(order) + "is null");

        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();

        return order;
    }
    public async Task<IEnumerable<Order>> AddAsync(IEnumerable<Order> orders)
    {
        if (orders is null || !orders.Any())
            throw new ArgumentNullException($"{typeof(Order).Name}s are null or empty");

        await _context.Orders.AddRangeAsync(orders);
        await _context.SaveChangesAsync();

        return orders;
    }

    public async Task<Order> EditAsync(Order order)
    {
        await CheckParameterIsExistingInDb(order);

        await Task.Run(() => _context.Orders.Update(order));
        await _context.SaveChangesAsync();

        return order;
    }
    public async Task<IEnumerable<Order>> EditAsync(IEnumerable<Order> orders)
    {
        await CheckParameterIsExistingInDb(orders);

        await Task.Run(() => _context.Orders.UpdateRange(orders));
        await _context.SaveChangesAsync();

        return orders;
    }

    public async Task RemoveAsync(Guid id)
    {
        Order orderFromDb = await GetAsync(id);
        
        await CheckParameterIsExistingInDb(orderFromDb);

        await Task.Run(() => _context.Orders.Remove(orderFromDb));
        await _context.SaveChangesAsync();
    }
    public async Task RemoveAsync(Order order)
    {
        await CheckParameterIsExistingInDb(order);

        await Task.Run(() => _context.Orders.Remove(order));
        await _context.SaveChangesAsync();
    }
    public async Task RemoveAsync(IEnumerable<Order> orders)
    {
        await CheckParameterIsExistingInDb(orders);

        await Task.Run(() => _context.Orders.RemoveRange(orders));
        await _context.SaveChangesAsync();
    }

    public async Task<IDbContextTransaction> BeginTransaction() =>
        await _context.BeginTransaction();
    
    private async Task CheckParameterIsExistingInDb(IEnumerable<Order> orders)
    {
        IEnumerable<Guid> ordersIds = orders.Select(e => e.Id);
        IEnumerable<Order> ordersFromDb = await GetAsync(e => ordersIds.Contains(e.Id));

        if (!ordersFromDb.Any() || ordersFromDb.Count() != orders.Count())
            throw new ArgumentNullException($"{typeof(Order).Name}s are not found in database");
    }
    private async Task CheckParameterIsExistingInDb(Order order)
    {
        Order orderFromDb = await GetAsync(order.Id);

        if (orderFromDb is null || orderFromDb.Id.Equals(Guid.Empty))
            throw new ArgumentNullException($"{typeof(Order).Name} is not found in database");
    }
}
