
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogHubStart.Models;

public class Employee
{
    [Key]
    public int EmployeeId { get; set; }
    [ForeignKey("Role")]
    [Required]
    public int RoleId { get; set; }
    public Role Role { get; set; }
    [Required]
    public string Username { get; set; }
    public string First { get; set; }
    public string Last { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public DateTimeOffset CreatedDate { get; set; }

    public ICollection<Order> Orders { get; set; }


}