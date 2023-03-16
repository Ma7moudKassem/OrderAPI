namespace OrdersDetails.Infrastructure;

public class OrdersDetailConfiguration : BaseEntityConfiguration<OrdersDetail>
{
    public override void Configure(EntityTypeBuilder<OrdersDetail> builder)
    {
        builder.ToTable("OrdersDetails");

        builder.Property(e => e.OrderId).IsRequired();
        builder.Property(e => e.ProductId).IsRequired();
        
        builder.Property(e => e.Discount).IsRequired();
        builder.Property(e => e.Quantity).IsRequired();
        builder.Property(e => e.UnitPrice).IsRequired();

        base.Configure(builder);
    }
}