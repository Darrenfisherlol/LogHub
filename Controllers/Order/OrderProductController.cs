using LogHubStart.Data;
using LogHubStart.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LogHubStart.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderProductController : ControllerBase
{
    private readonly AppDbContext _context;

    public OrderProductController(AppDbContext context)
    {
        _context = context;
    }

    //
    // RESTCRUD
    //

    [HttpGet]
    public async Task<IEnumerable<OrderProduct>> GetOrderProducts()
    {
        var orderProduct = await _context.OrderProduct.ToListAsync();
        return orderProduct;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<OrderProduct>> GetOrderProduct(int id)
    {
        var orderProduct = await _context.OrderProduct.FindAsync(id);

        if (orderProduct == null)
        {
            return NotFound();
        }

        return orderProduct;
    }

    [HttpPost]
    // overposting attacks
    // dto
    public async Task<ActionResult<OrderProduct>> PostOrderProduct(OrderProduct orderProduct)
    {
        if (orderProduct is null)
        {
            return BadRequest();
        }

        OrderProduct addOrderProduct = new OrderProduct
        {
            ProductId = orderProduct.ProductId,
            Product = orderProduct.Product,
            OrderId = orderProduct.OrderId,
            Order = orderProduct.Order,
            Quantity = orderProduct.Quantity,
        };

        await _context.OrderProduct.AddAsync(addOrderProduct);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetOrderProduct), new { id = orderProduct.OrderProductId });
    }

    [HttpPut("{id}")]
    // overposting attacks
    // dto
    public async Task<IActionResult> PutOrderProduct(int id, OrderProduct updateOrderProduct)
    {
        if (id != updateOrderProduct.OrderProductId)
        {
            return BadRequest();
        }

        _context.Entry(updateOrderProduct).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!OrderProductExists(id))
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
    public async Task<IActionResult> DeleteOrderProduct(int id)
    {
        var orderProductExists = OrderProductExists(id);
        if (!orderProductExists)
        {
            return NotFound();
        }

        var OrderProduct = await _context.OrderProduct.FindAsync(id);
        _context.OrderProduct.Remove(OrderProduct);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // Logic
    private bool OrderProductExists(int id)
    {
        var doesOrderProductExist = _context.OrderProduct.Any(e => e.OrderProductId == id);
        return doesOrderProductExist;
    }
}
