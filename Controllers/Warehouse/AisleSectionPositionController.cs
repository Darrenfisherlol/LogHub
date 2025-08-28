using LogHubStart.Data;
using LogHubStart.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LogHubStart.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AisleSectionPositionController : ControllerBase
{
    private readonly AppDbContext _context;

    public AisleSectionPositionController(AppDbContext context)
    {
        _context = context;
    }

    //
    // RESTCRUD
    //

    [HttpGet]
    public async Task<IEnumerable<AisleSectionPosition>> GetAisleSections()
    {
        var aisleSectionPositions = await _context.AisleSectionPosition.ToListAsync();
        return aisleSectionPositions;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AisleSectionPosition>> GetAisleSection(int id)
    {
        var aisleSectionPosition = await _context.AisleSectionPosition.FindAsync(id);

        if (aisleSectionPosition == null)
        {
            return NotFound();
        }

        return aisleSectionPosition;
    }

    [HttpPost]
    // overposting attacks
    // dto
    public async Task<ActionResult<AisleSection>> PostAisleSection(
        AisleSectionPosition aisleSectionPosition
    )
    {
        if (aisleSectionPosition is null)
        {
            return BadRequest();
        }

        AisleSectionPosition asp = new AisleSectionPosition
        {
            AisleSectionId = aisleSectionPosition.AisleSectionId,
            AisleSection = aisleSectionPosition.AisleSection,
            PositionCapacity = aisleSectionPosition.PositionCapacity,
            Height = aisleSectionPosition.Height,
            Width = aisleSectionPosition.Width,
            Length = aisleSectionPosition.Length,
        };

        await _context.AisleSectionPosition.AddAsync(asp);
        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetAisleSection),
            new { id = aisleSectionPosition.AisleSectionPositionId }
        );
    }

    [HttpPut("{id}")]
    // overposting attacks
    // dto
    public async Task<IActionResult> PutAisleSection(int id, AisleSection updateAisleSection)
    {
        if (id != updateAisleSection.AisleSectionId)
        {
            return BadRequest();
        }

        _context.Entry(updateAisleSection).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!AisleSectionPositionExists(id))
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
    public async Task<IActionResult> DeleteAisleSection(int id)
    {
        var aisleSectionPositionExists = AisleSectionPositionExists(id);
        if (!aisleSectionPositionExists)
        {
            return NotFound();
        }

        var aisleSectionPosition = await _context.AisleSectionPosition.FindAsync(id);
        _context.AisleSectionPosition.Remove(aisleSectionPosition);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // Logic
    public bool AisleSectionPositionExists(int id)
    {
        var doesAisleSectionPositionExist = _context.AisleSectionPosition.Any(e =>
            e.AisleSectionPositionId == id
        );
        return doesAisleSectionPositionExist;
    }
}
