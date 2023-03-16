namespace Shippers.Infrastructure;

public class ShipperUnitOfWork : BaseUnitOfWork<Shipper, IShippersDbContext>, IShipperUnitOfWork
{
    public ShipperUnitOfWork(IBaseRepository<Shipper, IShippersDbContext> repository) : base(repository) { }
}