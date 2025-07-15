using Microsoft.AspNetCore.Mvc;
using LogHubStart.Data;
using LogHubStart.Models;
using Microsoft.EntityFrameworkCore;

namespace LogHubStart.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IslandController : ControllerBase
{
    private readonly AppDbContext _context;

    public IslandController(AppDbContext context)
    {
        _context = context;
    }

    //
    // RESTCRUD
    //
    
    [HttpGet]
    public async Task<IEnumerable<Island>> GetIslands()
    {
        var islands = await _context.Island.ToListAsync();
        return islands;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Island>> GetIsland(int id)
    {
        var island = await _context.Island.FindAsync(id);

        if (island == null)
        {
            return NotFound();
        }

        return island;
    }

    [HttpPost]
    // overposting attacks
    // dto
    public async Task<ActionResult<Island>> PostIsland(Island island)
    {
        if (island is null)
        {
            return BadRequest();
        }
        
        IslandPosition islandUpdate = new IslandPosition
        {
            WarehouseSectionId = island.WarehouseSectionId,
            WarehouseSection = island.WarehouseSection
        };

        await _context.AddAsync(islandUpdate);
        await _context.SaveChangesAsync();
        
        return CreatedAtAction("GetIsland", new { id = island.IslandId });
    }

    [HttpPut("{id}")]
    // overposting attacks
    // dto
    public async Task<IActionResult> PutIsland(int id, Island updateIsland)
    {
        if (id != updateIsland.IslandId)
        {
            return BadRequest();
        }
        
        _context.Entry(updateIsland).State = EntityState.Modified;
        
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!IslandExists(id))
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
    public async Task<IActionResult> DeleteIsland(int id)
    {
        var islandExists = IslandExists(id);
        if (!islandExists)
        {
            return NotFound();
        }
        
        var island = await _context.Island.FindAsync(id);
        _context.Island.Remove(island);
        await _context.SaveChangesAsync();
        
        return NoContent();
    }
    
    // Logic
    public bool IslandExists(int id)
    {
        var doesIslandExist = _context.Island
            .Any(e => e.IslandId == id);
        return doesIslandExist;
    }
}
