using Microsoft.AspNetCore.Mvc;
using LogHubStart.Data;
using LogHubStart.Models;
using Microsoft.EntityFrameworkCore;

namespace LogHubStart.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AisleSectionController : ControllerBase
{
    private readonly AppDbContext _context;

    public AisleSectionController(AppDbContext context)
    {
        _context = context;
    }

    //
    // RESTCRUD
    //
    
    [HttpGet]
    public async Task<IEnumerable<AisleSection>> GetAisleSections()
    {
        var aisleSections = await _context.AisleSection.ToListAsync();
        return aisleSections;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AisleSection>> GetAisleSection(int id)
    {
        var aisleSection = await _context.AisleSection.FindAsync(id);

        if (aisleSection == null)
        {
            return NotFound();
        }

        return aisleSection;
    }

    [HttpPost]
    // overposting attacks
    // dto
    public async Task<ActionResult<AisleSection>> PostAisleSection(AisleSection aisleSection)
    {
        if (aisleSection is null)
        {
            return BadRequest();
        }
        
        AisleSection aisleSectionUpdate = new AisleSection
        {
            AisleId = aisleSection.AisleId,
            Aisle = aisleSection.Aisle,
            PositionCapacity = aisleSection.PositionCapacity,
            SectionName = aisleSection.SectionName
        };

        await _context.AisleSection.AddAsync(aisleSectionUpdate);
        await _context.SaveChangesAsync();
        
        return CreatedAtAction(nameof(GetAisleSection), new { id = aisleSection.AisleSectionId });
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
            if (!AisleSectionExists(id))
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
        var aisleSectionExists = AisleSectionExists(id);
        if (!aisleSectionExists)
        {
            return NotFound();
        }
        
        var aisleSection = await _context.AisleSection.FindAsync(id);
        _context.AisleSection.Remove(aisleSection);
        await _context.SaveChangesAsync();
        
        return NoContent();
    }
    
    // Logic
    public bool AisleSectionExists(int id)
    {
        var doesAisleSectionExist = _context.AisleSection
            .Any(e => e.AisleSectionId == id);
        return doesAisleSectionExist;
    }
}
