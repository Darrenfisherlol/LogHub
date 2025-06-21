using System.ComponentModel.DataAnnotations;

namespace LogHubStart.Models;

public class Customer
{
    [Key]
    public int CustomerId { get; set; }
    [Required]
    public string CustomerName { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Phone { get; set; }
    
    public DateTime CreatedDate { get; set; }

    public ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

}