namespace Shippers.Domain;

public class Shipper : BaseSettingsEntity
{
    public string Title { get; set; }
    public string TitleOfCourtesy { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string Region { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }
    public string HomePhone { get; set; }
    public string Extension { get; set; }
    public string Notes { get; set; }
    
    public int ReportsTo { get; set; }

    public DateTime HireDate { get; set; }
    public DateTime BirthDate { get; set; }
}