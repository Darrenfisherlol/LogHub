
namespace LogHubStart.Models;

public class InventoryMovement
{
    public int InventoryMovementId { get; set; }
    public int ItemStockId { get; set; }
    public int OrderProductId { get; set; }
    public int FromProductLocationId { get; set; }
    public int ToProductLocationId { get; set; }
    public int QuantityChange { get; set; }
    public DateTimeOffset MovementDate { get; set; }
    public int MovementBy { get; set; }
}