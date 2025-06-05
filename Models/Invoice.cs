namespace LogHubStart.Models;

public class Invoice
{
    public int InvoiceId { get; set; }
    public int CustomerId { get; set; }
    public int SupplierId { get; set; }
    public DateTimeOffset Date { get; set; }
    public double Amount { get; set; }
    public double Tax { get; set; }
    public double TotalAmount { get; set; }
    
}