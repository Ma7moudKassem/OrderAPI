namespace Shared.Contracts;

public class OrderDTO
{
    public Guid CustomerId { get; set; }
    public CustomerDTO Customer { get; set; }
    
    public Guid EmployeeId { get; set; }
    public EmployeeDTO Employee { get; set; }

    public string Freight { get; set; }
    public string ShipName { get; set; }
    public string ShipAddress { get; set; }
    public string ShipCity { get; set; }
    public string ShipRegion { get; set; }
    public string ShipPostalCode { get; set; }
    public string ShipCountry { get; set; }
}