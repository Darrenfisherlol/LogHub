using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogHubStart.Models;

public class Product
{
    [Key]
    public int ProductId { get; set; }

    [ForeignKey("ProductCategory")]
    public int CategoryId { get; set; }
    public ProductCategory ProductCategory { get; set; }

    [Required]
    public string SKU { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    [Required]
    public decimal Price { get; set; }

    public ICollection<OrderProduct> OrderProducts { get; set; }
    public ICollection<Item> ItemStocks { get; set; }
}
