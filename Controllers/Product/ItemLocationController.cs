using Microsoft.AspNetCore.Mvc;
using LogHubStart.Data;
using LogHubStart.Models;
using Microsoft.EntityFrameworkCore;

namespace LogHubStart.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ItemLocationController : ControllerBase
{
    private readonly AppDbContext _context;

    public ItemLocationController(AppDbContext context)
    {
        _context = context;
    }

    //
    // RESTCRUD
    //
    
    [HttpGet]
    public async Task<IEnumerable<ItemLocation>> GetItemLocations()
    {
        var itemLocation = await _context.ItemLocation.ToListAsync();
        return itemLocation;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ItemLocation>> GetItemLocation(int id)
    {
        var itemLocation = await _context.ItemLocation.FindAsync(id);

        if (itemLocation == null)
        {
            return NotFound();
        }

        return itemLocation;
    }

    [HttpPost]
    // overposting attacks
    // dto
    public async Task<ActionResult<ItemLocation>> PostItemLocation(ItemLocation itemLocation)
    {
        if (itemLocation is null)
        {
            return BadRequest();
        }
        
        ItemLocation addItemLocation = new ItemLocation
        {
            IslandPositionId = itemLocation.IslandPositionId,
            IslandPosition = itemLocation.IslandPosition,
            BinId = itemLocation.BinId,
            Bin = itemLocation.Bin,
            PositionId = itemLocation.PositionId,
            AisleSectionPosition = itemLocation.AisleSectionPosition,
        };

        await _context.ItemLocation.AddAsync(addItemLocation);
        await _context.SaveChangesAsync();
        
        return CreatedAtAction(nameof(GetItemLocation), new { id = ItemLocation.ItemLocationId });
    }

    [HttpPut("{id}")]
    // overposting attacks
    // dto
    public async Task<IActionResult> PutItemLocation(int id, ItemLocation updateItemLocation)
    {
        if (id != updateItemLocation.ItemLocationId)
        {
            return BadRequest();
        }
        
        _context.Entry(updateItemLocation).State = EntityState.Modified;
        
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ItemLocationExists(id))
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
    public async Task<IActionResult> DeleteItemLocation(int id)
    {
        var itemLocationExists = ItemLocationExists(id);
        if (!itemLocationExists)
        {
            return NotFound();
        }
        
        var itemLocation = await _context.ItemLocation.FindAsync(id);
        _context.ItemLocation.Remove(itemLocation);
        await _context.SaveChangesAsync();
        
        return NoContent();
    }
    
    // Logic
    public bool ItemLocationExists(int id)
    {
        var doesItemLocationExist = _context.ItemLocation
            .Any(e => e.ItemLocationId == id);
        return doesItemLocationExist;
    }
}
