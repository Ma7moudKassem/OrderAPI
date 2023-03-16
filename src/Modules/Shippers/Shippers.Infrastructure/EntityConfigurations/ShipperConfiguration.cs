namespace Shippers.Infrastructure;

public class ShipperConfiguration : BaseSettingsEntityConfiguration<Shipper>
{
    public override void Configure(EntityTypeBuilder<Shipper> builder)
    {
        builder.ToTable("Shippers");

        builder.Property(e => e.Title).IsRequired().HasMaxLength(30);
        builder.Property(e => e.TitleOfCourtesy).IsRequired().HasMaxLength(25);
        builder.Property(e => e.BirthDate).IsRequired();
        builder.Property(e => e.HireDate).IsRequired();
        builder.Property(e => e.Address).IsRequired().HasMaxLength(100);
        builder.Property(e => e.City).IsRequired().HasMaxLength(15);
        builder.Property(e => e.Region).IsRequired().HasMaxLength(25);
        builder.Property(e => e.PostalCode).IsRequired().HasMaxLength(10);
        builder.Property(e => e.Country).IsRequired().HasMaxLength(15);
        builder.Property(e => e.HomePhone).IsRequired().HasMaxLength(24);
        builder.Property(e => e.Notes).HasMaxLength(1000);

        base.Configure(builder);
    }
}