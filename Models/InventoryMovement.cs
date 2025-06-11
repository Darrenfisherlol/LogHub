
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogHubStart.Models;

/*public class InventoryMovement
{
    [Key]
    public int InventoryMovementId { get; set; }

    // the item 
    [Required]
    public int ItemStockId { get; set; }
    public ItemStock ItemStock { get; set; }
    
    // location of goods
    [Required]    
    public int ToOrderProductId { get; set; }
    public OrderProduct ToOrderProduct { get; set; }
    
    [Required]    
    public int FromProductLocationId { get; set; }
    public OrderProduct FromOrderProduct { get; set; }

    [Required]    
    public int ToProductLocationId { get; set; }
    public ProductLocation ProductLocation { get; set; }
    
    public int QuantityChange { get; set; }
    
    public DateTimeOffset MovementDate { get; set; }
    public int MovementBy { get; set; }
}*/


public class InventoryMovement
{
    [Key]
    public int InventoryMovementId { get; set; }

    [Required]
    public int ProductId { get; set; } 
    public Product Product { get; set; }

    [Required]
    public int FromProductLocationId { get; set; } 
    public ProductLocation FromProductLocation { get; set; }

    [Required]
    public int ToProductLocationId { get; set; } 
    public ProductLocation ToProductLocation { get; set; }

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