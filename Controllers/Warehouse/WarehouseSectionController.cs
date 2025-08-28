using LogHubStart.Data;
using LogHubStart.DTOs;
using LogHubStart.Models;
using Microsoft.AspNetCore.Mvc;
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
        //
        // Does the user have auth
        // Limit per linq
        //
        
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
    // overposting attacks ~ use dto
    public async Task<ActionResult> PostWarehouseSection(
        [FromBody] CreateWarehouseSectionDTO warehouseSectionDto
    )
    {
        if (warehouseSectionDto is null)
        {
            return BadRequest();
        }

        WarehouseSection newWarehouseSection = new WarehouseSection
        {
            WarehouseId = warehouseSectionDto.WarehouseId,
            Desc = warehouseSectionDto.Desc,
        };

        await _context.WarehouseSection.AddAsync(newWarehouseSection);
        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetWarehouseSection),
            new { id = newWarehouseSection.WarehouseSectionId }
        );
    }

    [HttpPut("{id}")]
    // overposting attacks
    // dto
    public async Task<IActionResult> PutWarehouseSection([FromBody] UpdateWarehouseSectionDTO dto)
    {
        var warehouseSection = await _context.WarehouseSection.FindAsync(dto.WarehouseSectionId);

        if (warehouseSection == null)
        {
            return NotFound();
        }
        
        warehouseSection.WarehouseId = dto.WarehouseId;
        warehouseSection.Desc = dto.Desc;
        
        await _context.SaveChangesAsync();
        
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteWarehouseSection(int id)
    {
        var warehouseSection = await _context.WarehouseSection.FirstOrDefaultAsync(x => x.WarehouseSectionId == id);
        if (warehouseSection is null)
        {
            return NotFound();
        }
        
        var hasStraightLine = await _context.StraightLine.AnyAsync(x => x.WarehouseSectionId == id);
        var hasBin = await _context.BinStorage.AnyAsync(x => x.WarehouseSectionsId == id);
        var hasIsland = await _context.Island.AnyAsync(x => x.WarehouseSectionsId == id);

        if (hasStraightLine || hasBin || hasIsland)
        {
            // cannot delete bc its used in a type of warehouse storage
            return BadRequest();
        }
        
        // user has auth check
        
        _context.WarehouseSection.Remove(warehouseSection);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
