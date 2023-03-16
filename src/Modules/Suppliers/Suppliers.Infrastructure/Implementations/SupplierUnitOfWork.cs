namespace Suppliers.Infrastructure;

public class SupplierUnitOfWork : BaseUnitOfWork<Supplier, ISuppliersDbContext>, ISupplierUnitOfWork
{
    public SupplierUnitOfWork(IBaseRepository<Supplier, ISuppliersDbContext> repository) : base(repository) { }
}