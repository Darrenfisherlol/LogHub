using Microsoft.AspNetCore.Mvc;
using LogHubStart.Data;
using LogHubStart.Models;
using Microsoft.EntityFrameworkCore;

namespace LogHubStart.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ItemController : ControllerBase
{
    private readonly AppDbContext _context;

    public ItemController(AppDbContext context)
    {
        _context = context;
    }

    //
    // RESTCRUD
    //
    
    [HttpGet]
    public async Task<IEnumerable<Item>> GetItems()
    {
        var item = await _context.Item.ToListAsync();
        return item;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Item>> GetItem(int id)
    {
        var item = await _context.Item.FindAsync(id);

        if (item == null)
        {
            return NotFound();
        }

        return item;
    }

    [HttpPost]
    // overposting attacks
    // dto
    public async Task<ActionResult<Item>> PostItem(Item item)
    {
        if (item is null)
        {
            return BadRequest();
        }
        
        Item addItem = new Item
        {
            ItemLocationId = item.ItemLocationId,
            ItemLocation = item.ItemLocation,
            ProductId = item.ProductId,
            Product = item.Product,
            Quantity = item.Quantity,
            Status = item.Status
        };

        await _context.Item.AddAsync(addItem);
        await _context.SaveChangesAsync();
        
        return CreatedAtAction(nameof(GetItem), new { id = Item.ItemId });
    }

    [HttpPut("{id}")]
    // overposting attacks
    // dto
    public async Task<IActionResult> PutItem(int id, Item updateItem)
    {
        if (id != updateItem.ItemId)
        {
            return BadRequest();
        }
        
        _context.Entry(updateItem).State = EntityState.Modified;
        
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ItemExists(id))
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
    public async Task<IActionResult> DeleteItem(int id)
    {
        var itemExists = ItemExists(id);
        if (!itemExists)
        {
            return NotFound();
        }
        
        var item = await _context.Item.FindAsync(id);
        _context.Item.Remove(item);
        await _context.SaveChangesAsync();
        
        return NoContent();
    }
    
    // Logic
    public bool ItemExists(int id)
    {
        var doesItemExist = _context.Item
            .Any(e => e.ItemId == id);
        return doesItemExist;
    }
}
