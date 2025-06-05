namespace LogHubStart.Models;

public class ItemStock
{
    public int ItemStockId { get; set; }
    public int ProductLocationId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public string Status { get; set; }
}