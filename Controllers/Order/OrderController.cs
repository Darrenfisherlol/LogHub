using Microsoft.AspNetCore.Mvc;
using LogHubStart.Data;
using LogHubStart.Models;
using Microsoft.EntityFrameworkCore;

namespace LogHubStart.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly AppDbContext _context;

    public OrderController(AppDbContext context)
    {
        _context = context;
    }

    //
    // RESTCRUD
    //
    
    [HttpGet]
    public async Task<IEnumerable<Order>> GetOrders()
    {
        var order = await _context.Order.ToListAsync();
        return order;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Order>> GetOrder(int id)
    {
        var order = await _context.Order.FindAsync(id);

        if (order == null)
        {
            return NotFound();
        }

        return order;
    }

    [HttpPost]
    // overposting attacks
    // dto
    public async Task<ActionResult<Order>> PostOrder(Order order)
    {
        if (order is null)
        {
            return BadRequest();
        }
        
        Order addOrder = new Order
        {
            InvoiceId = order.InvoiceId,
            Invoice = order.Invoice,
            EmployeeId = order.EmployeeId,
            Employee = order.Employee,
            StartDate = order.StartDate,
            EndDate = order.EndDate
        };

        await _context.AddAsync(addOrder);
        await _context.SaveChangesAsync();
        
        return CreatedAtAction(nameof(GetOrder), new { id = Order.OrderId });
    }

    [HttpPut("{id}")]
    // overposting attacks
    // dto
    public async Task<IActionResult> PutOrder(int id, Order updateOrder)
    {
        if (id != updateOrder.OrderId)
        {
            return BadRequest();
        }
        
        _context.Entry(updateOrder).State = EntityState.Modified;
        
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!OrderExists(id))
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
    public async Task<IActionResult> DeleteOrder(int id)
    {
        var orderExists = OrderExists(id);
        if (!orderExists)
        {
            return NotFound();
        }
        
        var order = await _context.Order.FindAsync(id);
        _context.Order.Remove(order);
        await _context.SaveChangesAsync();
        
        return NoContent();
    }
    
    // Logic
    public bool OrderExists(int id)
    {
        var doesOrderExist = _context.Order
            .Any(e => e.OrderId == id);
        return doesOrderExist;
    }
}
