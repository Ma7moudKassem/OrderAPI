namespace Suppliers.Infrastructure;

public class SupplierRepository : BaseRepository<Supplier, ISuppliersDbContext>, ISupplierRepository
{
    public SupplierRepository(ISuppliersDbContext context) : base(context) { }
}