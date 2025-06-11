using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogHubStart.Models;

public class ItemStock
{
    [Key]
    public int ItemStockId { get; set; }
    
    [ForeignKey("ProductLocation")]
    public int ProductLocationId { get; set; }
    public ProductLocation ProductLocation { get; set; }
    
    [ForeignKey("Product")]
    [Required]
    public int ProductId { get; set; }
    public Product Product { get; set; }
    
    public int Quantity { get; set; }
    public string Status { get; set; }
}