using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogHubStart.Models;

public class Order
{
    [Key]
    public int OrderId { get; set; }
    
    [ForeignKey("Invoice")]
    public int InvoiceId { get; set; }
    public Invoice Invoice { get; set; }
    
    [ForeignKey("Employee")]
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }
    
    [Required]
    public DateTimeOffset StartDate { get; set; }
    [Required]
    public DateTimeOffset EndDate { get; set; }
    
    // an order can have many Products and a product can be on many orders
    public ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();

}