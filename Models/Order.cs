namespace LogHubStart.Models;

public class Order
{
    public int OrderId { get; set; }
    public int InvoiceId { get; set; }
    public int EmployeeId { get; set; }
    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset EndDate { get; set; }
    
}