using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogHubStart.Models;

public class Invoice
{
    [Key]
    public int InvoiceId { get; set; }

    [ForeignKey("Customer")]
    public int? CustomerId { get; set; }
    public Customer? Customer { get; set; }

    [ForeignKey("Supplier")]
    public int? SupplierId { get; set; }
    public Supplier? Supplier { get; set; }

    public DateTime Date { get; set; }

    public decimal Amount { get; set; }
    public decimal Tax { get; set; }

    // implies 1 to 1 relationship ~ 1 invoice 1 order
    public Order Orders { get; set; }
}
