namespace Shippers.Infrastructure;

public class ShipperRepository : BaseRepository<Shipper, IShippersDbContext>, IShipperRepository
{
    public ShipperRepository(IShippersDbContext context) : base(context) { }
}