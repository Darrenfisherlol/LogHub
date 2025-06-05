
namespace LogHubStart.Models;

public class Employee
{
    public int EmployeeId { get; set; }
    public int RoleId { get; set; }
    public string Username { get; set; }
    public string First { get; set; }
    public string Last { get; set; }
    public string Email { get; set; }
    public DateTimeOffset CreatedDate { get; set; }

}