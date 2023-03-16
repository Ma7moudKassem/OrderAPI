namespace OrdersDetails.Domain;

public partial class OrdersDetail
{
    [NotMapped] public OrderDTO? Order { get; set; }
}