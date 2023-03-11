namespace Customers.Infrastructure;

public class CustomerConfiguration : BaseEntityConfiguration<Customer>
{
    public override void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers");

        builder.Property(e => e.CompanyName).IsRequired().HasMaxLength(40);
        builder.Property(e => e.ContactName).IsRequired().HasMaxLength(30);
        builder.Property(e => e.ContactTitle).IsRequired().HasMaxLength(30);
        builder.Property(e => e.Address).IsRequired().HasMaxLength(60);
        builder.Property(e => e.City).IsRequired().HasMaxLength(15);
        builder.Property(e => e.Region).IsRequired().HasMaxLength(15);
        builder.Property(e => e.PostalCold).IsRequired().HasMaxLength(10);
        builder.Property(e => e.Country).IsRequired().HasMaxLength(15);
        builder.Property(e => e.Phone).IsRequired().HasMaxLength(24);
        builder.Property(e => e.Fax).IsRequired().HasMaxLength(24);

        base.Configure(builder);
    }
}