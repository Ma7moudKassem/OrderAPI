namespace Customers.Infrastructure;

public class CustomerConfiguration : BaseEntityConfiguration<Customer>
{
    public override void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers");

        base.Configure(builder);
    }
}