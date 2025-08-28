using System.ComponentModel.DataAnnotations;

namespace LogHubStart.Models;

public class Role
{
    [Key]
    public int RoleId { get; set; }
    public bool AdminAccess { get; set; }
    public bool ManagerAccess { get; set; }
    public bool WorkerAccess { get; set; }

    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
