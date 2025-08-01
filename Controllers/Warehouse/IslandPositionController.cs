using LogHubStart.Data;
using LogHubStart.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LogHubStart.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IslandPositionController : ControllerBase
{
    private readonly AppDbContext _context;

    public IslandPositionController(AppDbContext context)
    {
        _context = context;
    }

    //
    // RESTCRUD
    //

    [HttpGet]
    public async Task<IEnumerable<IslandPosition>> GetIslandPositions()
    {
        var islandPositions = await _context.IslandPosition.ToListAsync();
        return islandPositions;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<IslandPosition>> GetIslandPosition(int id)
    {
        var islandPosition = await _context.IslandPosition.FindAsync(id);

        if (islandPosition == null)
        {
            return NotFound();
        }

        return islandPosition;
    }

    [HttpPost]
    // overposting attacks
    // dto
    public async Task<ActionResult<IslandPosition>> PostIslandPosition(
        IslandPosition islandPosition
    )
    {
        if (islandPosition is null)
        {
            return BadRequest();
        }

        IslandPosition updatedIslandPosition = new IslandPosition
        {
            IslandId = islandPosition.IslandId,
            Island = islandPosition.Island,
            IslandCapacity = islandPosition.IslandCapacity,
            Height = islandPosition.Height,
            Width = islandPosition.Width,
            Length = islandPosition.Length,
        };

        await _context.IslandPosition.AddAsync(updatedIslandPosition);
        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetIslandPositions),
            new { id = islandPosition.IslandPositionId }
        );
    }

    [HttpPut("{id}")]
    // overposting attacks
    // dto
    public async Task<IActionResult> PutIslandPosition(int id, IslandPosition updateIslandPosition)
    {
        if (id != updateIslandPosition.IslandPositionId)
        {
            return BadRequest();
        }

        _context.Entry(updateIslandPosition).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!IslandPositionExists(id))
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
    public async Task<IActionResult> DeleteIslandPosition(int id)
    {
        var islandPositionExists = IslandPositionExists(id);
        if (!islandPositionExists)
        {
            return NotFound();
        }

        var islandPosition = await _context.IslandPosition.FindAsync(id);
        _context.IslandPosition.Remove(islandPosition);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // Logic
    public bool IslandPositionExists(int id)
    {
        var doesIslandPositionExist = _context.IslandPosition.Any(e => e.IslandPositionId == id);
        return doesIslandPositionExist;
    }
}
