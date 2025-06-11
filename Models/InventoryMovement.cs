
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogHubStart.Models;


public class InventoryMovement
{
    [Key]
    public int InventoryMovementId { get; set; }

    [Required]
    public int ItemId { get; set; } 
    public Item Item { get; set; }

    [Required]
    public int FromProductLocationId { get; set; } 
    public ItemLocation FromItemLocation { get; set; }

    [Required]
    public int ToProductLocationId { get; set; } 
    public ItemLocation ToItemLocation { get; set; }

    public string Status { get; set; }
    
    [Required]
    public int QuantityChange { get; set; }

    [Required]
    public DateTimeOffset MovementDate { get; set; }

    [Required]
    public int MovementByEmployeeId { get; set; } 
    public Employee MovementByEmployee { get; set; }
    
    // if movement to fill and order or just bc 
    public int? OrderProductId { get; set; }
    public OrderProduct? OrderProduct { get; set; }
}