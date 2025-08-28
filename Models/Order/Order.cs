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
    public DateTime StartDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }

    public ICollection<OrderProduct> OrderProducts { get; set; }
    public ICollection<Item> FulfilledItems { get; set; }
}
