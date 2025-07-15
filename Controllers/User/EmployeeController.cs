using Microsoft.AspNetCore.Mvc;
using LogHubStart.Data;
using LogHubStart.Models;
using Microsoft.EntityFrameworkCore;

namespace LogHubStart.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly AppDbContext _context;

    public EmployeeController(AppDbContext context)
    {
        _context = context;
    }

    //
    // RESTCRUD
    //
    
    [HttpGet]
    public async Task<IEnumerable<Employee>> GetEmployees()
    {
        var employee = await _context.Employee.ToListAsync();
        return employee;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Employee>> GetEmployee(int id)
    {
        var employee = await _context.Employee.FindAsync(id);

        if (employee == null)
        {
            return NotFound();
        }

        return employee;
    }

    [HttpPost]
    // overposting attacks
    // dto
    public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
    {
        if (employee is null)
        {
            return BadRequest();
        }
        
        
        Employee addEmployee = new Employee
        {
            RoleId = employee.RoleId,
            Role = employee.Role,
            Username = employee.Username,
            First = employee.First,
            Last = employee.Last,
            Email = employee.Email,
            CreatedDate = employee.CreatedDate
        };

        await _context.Employee.AddAsync(addEmployee);
        await _context.SaveChangesAsync();
        
        return CreatedAtAction(nameof(GetEmployee), new { id = Employee.EmployeeId });
    }

    [HttpPut("{id}")]
    // overposting attacks
    // dto
    public async Task<IActionResult> PutEmployee(int id, Employee updateEmployee)
    {
        if (id != updateEmployee.EmployeeId)
        {
            return BadRequest();
        }
        
        _context.Entry(updateEmployee).State = EntityState.Modified;
        
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!EmployeeExists(id))
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
    public async Task<IActionResult> DeleteEmployee(int id)
    {
        var employeeExists = EmployeeExists(id);
        if (!employeeExists)
        {
            return NotFound();
        }
        
        var employee = await _context.Employee.FindAsync(id);
        _context.Employee.Remove(employee);
        await _context.SaveChangesAsync();
        
        return NoContent();
    }
    
    // Logic
    public bool EmployeeExists(int id)
    {
        var doesEmployeeExist = _context.Employee
            .Any(e => e.EmployeeId == id);
        return doesEmployeeExist;
    }
}
