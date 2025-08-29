using LogHubStart.Data;
using LogHubStart.DTOs;
using LogHubStart.Models;
using Microsoft.AspNetCore.Mvc;
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
    public async Task<ActionResult<StraightLine>> PostStraightLine([FromBody] CreateStraightLineDTO dto)
    {
        if (dto is null)
        {
            return BadRequest();
        }

        var sectionExists = await _context.WarehouseSection.AnyAsync(x => x.WarehouseSectionId == dto.WarehouseSectionId);
        
        if (!sectionExists)
        {
            return BadRequest("Warehouse section does not exist");
        }

        StraightLine newStraightLine = new StraightLine
        {
            WarehouseSectionId = dto.WarehouseSectionId        
        };

        await _context.StraightLine.AddAsync(newStraightLine);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetStraightLine), new { id = newStraightLine.StraightLineID });
    }

    [HttpPut("{id}")]
    // overposting attacks
    // use a dto
    public async Task<IActionResult> PutStraightLine([FromBody] UpdateStraightLineDTO dto)
    {
        
        var straightLine = await _context.StraightLine.FindAsync(dto.StraightLineID);
        if (straightLine == null)
        {
            // pass the id back on all controllers
            return NotFound($"Straight line with ID {dto.StraightLineID} not found");
        }

        var straightLineExists = await _context.WarehouseSection.AnyAsync(x => x.WarehouseSectionId == dto.WarehouseSectionId);
        if (!straightLineExists)
        {
            return BadRequest("StraightLine section does not exist");
        }

        // change data ~ avoid overposting by emphasizing what changes
        straightLine.WarehouseSectionId = dto.WarehouseSectionId;
        
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStraightLine(int id)
    {
        var straightLine = await _context.StraightLine.FindAsync(id);
        if (straightLine == null)
        {
            return NotFound($"Straight line with ID {id} not found");
        }

        // add parent check
        
        _context.StraightLine.Remove(straightLine);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
