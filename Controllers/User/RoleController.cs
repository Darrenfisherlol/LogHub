using Microsoft.AspNetCore.Mvc;
using LogHubStart.Data;
using LogHubStart.Models;
using Microsoft.EntityFrameworkCore;

namespace LogHubStart.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoleController : ControllerBase
{
    private readonly AppDbContext _context;

    public RoleController(AppDbContext context)
    {
        _context = context;
    }

    //
    // RESTCRUD
    //
    
    [HttpGet]
    public async Task<IEnumerable<Role>> GetRoles()
    {
        var role = await _context.Role.ToListAsync();
        return role;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Role>> GetRole(int id)
    {
        var role = await _context.Role.FindAsync(id);

        if (role == null)
        {
            return NotFound();
        }

        return role;
    }

    [HttpPost]
    // overposting attacks
    // dto
    public async Task<ActionResult<Role>> PostRole(Role role)
    {
        if (role is null)
        {
            return BadRequest();
        }
        
        
        Role addRole = new Role
        {
            AdminAccess = role.AdminAccess,
            ManagerAccess = role.ManagerAccess,
            WorkerAccess = role.WorkerAccess
        };

        await _context.Role.AddAsync(addRole);
        await _context.SaveChangesAsync();
        
        return CreatedAtAction(nameof(GetRole), new { id = Role.RoleId });
    }

    [HttpPut("{id}")]
    // overposting attacks
    // dto
    public async Task<IActionResult> PutRole(int id, Role updateRole)
    {
        if (id != updateRole.RoleId)
        {
            return BadRequest();
        }
        
        _context.Entry(updateRole).State = EntityState.Modified;
        
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!RoleExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRole(int id)
    {
        var roleExists = RoleExists(id);
        if (!roleExists)
        {
            return NotFound();
        }
        
        var role = await _context.Role.FindAsync(id);
        _context.Role.Remove(role);
        await _context.SaveChangesAsync();
        
        return NoContent();
    }
    
    // Logic
    public bool RoleExists(int id)
    {
        var doesRoleExist = _context.Role
            .Any(e => e.RoleId == id);
        return doesRoleExist;
    }
}
