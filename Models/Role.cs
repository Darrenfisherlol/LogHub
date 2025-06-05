
namespace LogHubStart.Models;

public class Role
{
    public int RoleId { get; set; }
    public bool AdminAccess { get; set; }
    public bool ManagerAccess { get; set; }
    public bool WorkerAccess { get; set; }
    

}