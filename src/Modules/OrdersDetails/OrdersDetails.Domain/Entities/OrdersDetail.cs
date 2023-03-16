namespace OrdersDetails.Domain;

public partial class OrdersDetail : BaseEntity
{
    public Guid OrderId { get; set; }
    public Guid ProductId { get; set; }

    public float UnitPrice { get; set; }
    public float Discount { get; set; }
    public float Quantity { get; set; }
}