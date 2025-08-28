using System.ComponentModel.DataAnnotations;

namespace LogHubStart.Models;

public class Supplier
{
    [Key]
    public int SupplierId { get; set; }

    [Required]
    public string SupplierName { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public string Phone { get; set; }

    public ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
}
