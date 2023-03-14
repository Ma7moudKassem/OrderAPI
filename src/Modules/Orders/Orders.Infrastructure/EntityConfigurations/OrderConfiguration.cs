namespace Orders.Infrastructure;

public class OrderConfiguration : BaseEntityConfiguration<Order>
{
    public override void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders");

        builder.Property(e => e.CustomerId).IsRequired();
        builder.Property(e => e.EmployeeId).IsRequired();

        builder.Property(e => e.Freight).IsRequired().HasMaxLength(20);
        builder.Property(e => e.ShipName).IsRequired().HasMaxLength(40);
        builder.Property(e => e.ShipAddress).IsRequired().HasMaxLength(60);
        builder.Property(e => e.ShipCity).IsRequired().HasMaxLength(15);
        builder.Property(e => e.ShipRegion).IsRequired().HasMaxLength(15);
        builder.Property(e => e.ShipPostalCode).IsRequired().HasMaxLength(10);
        builder.Property(e => e.ShipCountry).IsRequired().HasMaxLength(15);

        builder.Property(e => e.ShipVia).IsRequired();

        builder.Property(e => e.OrderDate).IsRequired();
        builder.Property(e => e.ShippedDate).IsRequired();
        builder.Property(e => e.RequiredDate).IsRequired();

        base.Configure(builder);
    }
}