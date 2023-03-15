using Shared.Contracts;
using System.ComponentModel.DataAnnotations.Schema;

namespace Orders.Domain;

public class Order : BaseEntity
{
    public Guid CustomerId { get; set; }
    [NotMapped] public CustomerDTO? Customer { get; set; }
    public Guid EmployeeId { get; set; }

    public string Freight { get; set; }
    public string ShipName { get; set; }
    public string ShipAddress { get; set; }
    public string ShipCity { get; set; }
    public string ShipRegion { get; set; }
    public string ShipPostalCode { get; set; }
    public string ShipCountry { get; set; }

    public int ShipVia { get; set; }

    public DateTime OrderDate { get; set; }
    public DateTime RequiredDate { get; set; }
    public DateTime ShippedDate { get; set; }
}
