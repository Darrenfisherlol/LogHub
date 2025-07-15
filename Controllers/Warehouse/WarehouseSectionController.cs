using Microsoft.AspNetCore.Mvc;
using LogHubStart.Data;
using LogHubStart.Models;
using Microsoft.EntityFrameworkCore;

namespace LogHubStart.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WarehouseSectionController : ControllerBase
{
    private readonly AppDbContext _context;

    public WarehouseSectionController(AppDbContext context)
    {
        _context = context;
    }

    //
    // RESTCRUD
    //
    
    [HttpGet]
    public async Task<IEnumerable<WarehouseSection>> GetWarehouseSections()
    {
        var warehouseSections = await _context.WarehouseSection.ToListAsync();
        return warehouseSections;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<WarehouseSection>> GetWarehouseSection(int id)
    {
        var warehouseSection = await _context.WarehouseSection.FindAsync(id);

        if (warehouseSection == null)
        {
            return NotFound();
        }

        return warehouseSection;
    }

    [HttpPost]
    // overposting attacks
    // dto
    public async Task<ActionResult<WarehouseSection>> PostWarehouseSection(WarehouseSection warehouseSection)
    {
        if (warehouseSection is null)
        {
            return BadRequest();
        }
        
        
        Warehouse addWarehouseSection = new Warehouse
        {
            WarehouseId = warehouseSection.WarehouseId,
            Warehouse = warehouseSection.Warehouse,
            Desc = warehouseSection.Desc
        };

        await _context.WarehouseSection.AddAsync(addWarehouseSection);
        await _context.SaveChangesAsync();
        
        return CreatedAtAction(nameof(GetWarehouseSection), new { id = warehouseSection.WarehouseSectionId });
    }

    [HttpPut("{id}")]
    // overposting attacks
    // dto
    public async Task<IActionResult> PutWarehouseSection(int id, WarehouseSection updateWarehouseSection)
    {
        if (id != updateWarehouseSection.WarehouseSectionId)
        {
            return BadRequest();
        }
        
        _context.Entry(updateWarehouseSection).State = EntityState.Modified;
        
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!WarehouseSectionExists(id))
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
    public async Task<IActionResult> DeleteWarehouseSection(int id)
    {
        var warehouseSectionExists = WarehouseSectionExists(id);
        if (!warehouseSectionExists)
        {
            return NotFound();
        }
        
        var warehouseSection = await _context.WarehouseSection.FindAsync(id);
        _context.WarehouseSection.Remove(warehouseSection);
        await _context.SaveChangesAsync();
        
        return NoContent();
    }
    
    // Logic
    public bool WarehouseSectionExists(int id)
    {
        var doesWarehouseSectionExist = _context.WarehouseSection
            .Any(e => e.WarehouseSectionId == id);
        return doesWarehouseSectionExist;
    }
}
