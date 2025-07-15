using Microsoft.AspNetCore.Mvc;
using LogHubStart.Data;
using LogHubStart.Models;
using Microsoft.EntityFrameworkCore;

namespace LogHubStart.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StraightLineController : ControllerBase
{
    private readonly AppDbContext _context;

    public StraightLineController(AppDbContext context)
    {
        _context = context;
    }

    //
    // RESTCRUD
    //
    
    [HttpGet]
    public async Task<IEnumerable<StraightLine>> GetStraightLines()
    {
        var straightLines = await _context.StraightLine.ToListAsync();
        return straightLines;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<StraightLine>> GetStraightLine(int id)
    {
        var straightLine = await _context.StraightLine.FindAsync(id);

        if (straightLine == null)
        {
            return NotFound();
        }

        return straightLine;
    }

    [HttpPost]
    // overposting attacks
    // dto
    public async Task<ActionResult<StraightLine>> PostStraightLine(StraightLine straightLine)
    {
        if (straightLine is null)
        {
            return BadRequest();
        }
        
        StraightLine straightlineAdd = new StraightLine
        {
            WarehouseSectionId = straightLine.WarehouseSectionId,
            WarehouseSection = straightLine.WarehouseSection
        };

        await _context.AddAsync(straightlineAdd);
        await _context.SaveChangesAsync();
        
        return CreatedAtAction("GetStraightLine", new { id = straightLine.StraightLineID });
    }

    [HttpPut("{id}")]
    // overposting attacks
    // dto
    public async Task<IActionResult> PutStraightLine(int id, StraightLine updateStraightLine)
    {
        if (id != updateStraightLine.StraightLineID)
        {
            return BadRequest();
        }
        
        _context.Entry(updateStraightLine).State = EntityState.Modified;
        
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!StraightLineExists(id))
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
    public async Task<IActionResult> DeleteStraightLine(int id)
    {
        var straightLineExists = StraightLineExists(id);
        if (!straightLineExists)
        {
            return NotFound();
        }
        
        var straightLine = await _context.StraightLine.FindAsync(id);
        _context.StraightLine.Remove(straightLine);
        await _context.SaveChangesAsync();
        
        return NoContent();
    }
    
    // Logic
    public bool StraightLineExists(int id)
    {
        var doesStraightLineExist = _context.StraightLine
            .Any(e => e.StraightLineID == id);
        return doesStraightLineExist;
    }
}
