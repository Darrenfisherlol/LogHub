
namespace LogHubStart.Models;

public class Warehouse
{
    public int WarehouseId { get; set; }
    public string WarehouseName { get; set; }
    public string Address { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public int ZipCode { get; set; }
    public string OwnerName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string CreatedBy { get; set; }
    public string CreatedDate { get; set; }
    public string UpdateBy { get; set; }
    public DateTimeOffset UpdateDate { get; set; }
}