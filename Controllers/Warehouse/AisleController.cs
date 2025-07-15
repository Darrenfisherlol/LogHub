using Microsoft.AspNetCore.Mvc;
using LogHubStart.Data;
using LogHubStart.Models;
using Microsoft.EntityFrameworkCore;

namespace LogHubStart.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AisleController : ControllerBase
{
    private readonly AppDbContext _context;

    public AisleController(AppDbContext context)
    {
        _context = context;
    }

    //
    // RESTCRUD
    //
    
    [HttpGet]
    public async Task<IEnumerable<Aisle>> GetAisles()
    {
        var aisles = await _context.Aisle.ToListAsync();
        return aisles;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Aisle>> GetAisle(int id)
    {
        var aisle = await _context.Aisle.FindAsync(id);

        if (aisle == null)
        {
            return NotFound();
        }

        return aisle;
    }

    [HttpPost]
    // overposting attacks
    // dto
    public async Task<ActionResult<Aisle>> PostAisle(Aisle aisle)
    {
        if (aisle is null)
        {
            return BadRequest();
        }
        
         Aisle aisleUpdate = new Aisle
        {
            StraightLineId = aisle.StraightLineId,
            StraightLine = aisle.StraightLine,
            AisleName = aisle.AisleName
        };

        await _context.Aisle.AddAsync(aisleUpdate);
        await _context.SaveChangesAsync();
        
        return CreatedAtAction(nameof(GetAisle), new { id = aisle.AisleId });
    }

    [HttpPut("{id}")]
    // overposting attacks
    // dto
    public async Task<IActionResult> PutAisle(int id, Aisle updateAisle)
    {
        if (id != updateAisle.AisleId)
        {
            return BadRequest();
        }
        
        _context.Entry(updateAisle).State = EntityState.Modified;
        
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!AisleExists(id))
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
    public async Task<IActionResult> DeleteAisle(int id)
    {
        var aisleExists = AisleExists(id);
        if (!aisleExists)
        {
            return NotFound();
        }
        
        var aisle = await _context.Aisle.FindAsync(id);
        _context.Aisle.Remove(aisle);
        await _context.SaveChangesAsync();
        
        return NoContent();
    }
    
    // Logic
    public bool AisleExists(int id)
    {
        var doesAisleExist = _context.Aisle
            .Any(e => e.AisleId == id);
        return doesAisleExist;
    }
}
