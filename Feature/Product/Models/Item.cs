using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogHubStart.Models;

public class Item
{
    [Key]
    public int ItemId { get; set; }
    
    [ForeignKey("ProductLocation")]
    public int ProductLocationId { get; set; }
    public ItemLocation ItemLocation { get; set; }
    
    [ForeignKey("Product")]
    [Required]
    public int ProductId { get; set; }
    public Product Product { get; set; }
    
    public int Quantity { get; set; }
    public string Status { get; set; }
}