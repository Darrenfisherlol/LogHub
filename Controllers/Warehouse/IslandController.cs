using LogHubStart.Data;
using LogHubStart.DTOs;

using LogHubStart.Models;
using Microsoft.AspNetCore.Mvc;
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
    public async Task<ActionResult<Island>> PostIsland([FromBody] CreateIslandDTO dto)
    {
        if (dto is null)
        {
            return BadRequest("dto is null");
        }

        var islandExists = await _context.Island.AnyAsync(x => x.IslandId == dto.WarehouseSectionsId);
        if (!islandExists)
        {
            return BadRequest("Warehouse section does not exist");
        }

        Island newIsland = new Island
        {
            WarehouseSectionsId = dto.WarehouseSectionsId,
        };

        await _context.AddAsync(newIsland);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetIsland), new { id = newIsland.IslandId });
    }

    [HttpPut("{id}")]
    // overposting attacks
    // dto
    public async Task<IActionResult> PutIsland(int id, [FromBody] UpdateIslandDTO dto)
    {
        var island = await _context.Island.FindAsync(id);
        if (island == null)
        {
            return NotFound($"Island with ID {id} not found");
        }

        var sectionExists = await _context.Island.AnyAsync(x => x.IslandId == dto.IslandId);
        if (!sectionExists)
        {
            return BadRequest("Island does not exist");
        }

        island.WarehouseSectionsId = dto.WarehouseSectionsId;
        
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteIsland(int id)
    {
        var island = await _context.Island.FindAsync(id);
        if (island == null)
        {
            return NotFound($"Island with ID {id} not found");
        }

        _context.Island.Remove(island);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
