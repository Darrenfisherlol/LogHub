using Microsoft.AspNetCore.Mvc;
using LogHubStart.Data;
using LogHubStart.Models;
using Microsoft.EntityFrameworkCore;

namespace LogHubStart.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly AppDbContext _context;

    public CustomerController(AppDbContext context)
    {
        _context = context;
    }

    //
    // RESTCRUD
    //
    
    [HttpGet]
    public async Task<IEnumerable<Customer>> GetCustomers()
    {
        var customer = await _context.Customer.ToListAsync();
        return customer;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Customer>> GetCustomer(int id)
    {
        var customer = await _context.Customer.FindAsync(id);

        if (customer == null)
        {
            return NotFound();
        }

        return customer;
    }

    [HttpPost]
    // overposting attacks
    // dto
    public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
    {
        if (customer is null)
        {
            return BadRequest();
        }
        
        
        Customer addCustomer = new Customer
        {
            CustomerName = customer.Name,
            Email = customer.Email,
            Phone = customer.Phone,
            CreatedDate = customer.CreatedDate
        };

        await _context.AddAsync(addCustomer);
        await _context.SaveChangesAsync();
        
        return CreatedAtAction(nameof(GetCustomer), new { id = Customer.CustomerId });
    }

    [HttpPut("{id}")]
    // overposting attacks
    // dto
    public async Task<IActionResult> PutCustomer(int id, Customer updateCustomer)
    {
        if (id != updateCustomer.CustomerId)
        {
            return BadRequest();
        }
        
        _context.Entry(updateCustomer).State = EntityState.Modified;
        
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CustomerExists(id))
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
    public async Task<IActionResult> DeleteCustomer(int id)
    {
        var customerExists = CustomerExists(id);
        if (!customerExists)
        {
            return NotFound();
        }
        
        var customer = await _context.Customer.FindAsync(id);
        _context.Customer.Remove(customer);
        await _context.SaveChangesAsync();
        
        return NoContent();
    }
    
    // Logic
    public bool CustomerExists(int id)
    {
        var doesCustomerExist = _context.Customer
            .Any(e => e.CustomerId == id);
        return doesCustomerExist;
    }
}
