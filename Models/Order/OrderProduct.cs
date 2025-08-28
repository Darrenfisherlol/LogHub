using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogHubStart.Models;

public class OrderProduct
{
    [Key]
    public int OrderProductId { get; set; }

    [ForeignKey("Product")]
    [Required]
    public int ProductId { get; set; }
    public Product Product { get; set; }

    [ForeignKey("Order")]
    [Required]
    public int OrderId { get; set; }
    public Order Order { get; set; }

    public int Quantity { get; set; }
}
