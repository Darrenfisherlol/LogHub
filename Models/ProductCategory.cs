using System.ComponentModel.DataAnnotations;

namespace LogHubStart.Models;

public class ProductCategory
{
    [Key]
    public int CategoryId { get; set; }
    
    [Required]
    public string CategoryName { get; set; }
    
    [Required]
    public string CategoryDescription { get; set; }
    
    public ICollection<Product> Products { get; set; } = new List<Product>();

}