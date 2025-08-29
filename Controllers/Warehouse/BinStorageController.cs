using LogHubStart.Data;
using LogHubStart.DTOs;
using LogHubStart.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LogHubStart.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BinStorageController : ControllerBase
{
    private readonly AppDbContext _context;

    public BinStorageController(AppDbContext context)
    {
        _context = context;
    }

    //
    // RESTCRUD
    //

    [HttpGet]
    public async Task<IEnumerable<BinStorage>> GetBinStorages()
    {
        var binStorages = await _context.BinStorage.ToListAsync();
        return binStorages;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BinStorage>> GetBinStorage(int id)
    {
        var binStorage = await _context.BinStorage.FindAsync(id);

        if (binStorage == null)
        {
            return NotFound();
        }

        return binStorage;
    }

    [HttpPost]
    // overposting attacks
    // dto
    public async Task<ActionResult<BinStorage>> PostBinStorage([FromBody] CreateBinStorageDTO dto)
    {
        if (dto is null)
        {
            return BadRequest();
        }

        var sectionExists = await _context.WarehouseSection.AnyAsync(ws => ws.WarehouseSectionId == dto.WarehouseSectionsId);
        if (!sectionExists)
        {
            return BadRequest("Specified warehouse section does not exist");
        }

        BinStorage newBinStorage = new BinStorage
        {
            WarehouseSectionsId = dto.WarehouseSectionsId,
            Row = dto.Row,
        };

        await _context.BinStorage.AddAsync(newBinStorage);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetBinStorage), new { id = newBinStorage.BinStorageId });
    }

    [HttpPut("{id}")]
    // overposting attacks
    // dto
    public async Task<IActionResult> PutBinStorage(int id, [FromBody] UpdateBinStorageDTO dto)
    {
        var binStorage = await _context.BinStorage.FindAsync(dto.BinStorageId);
        if (binStorage == null)
        {
            return NotFound($"Bin storage with ID {dto.BinStorageId} not found");
        }

        var binStorageExists = await _context.BinStorage.AnyAsync(x => x.BinStorageId == dto.BinStorageId);
        if (!binStorageExists)
        {
            return BadRequest("Bin storage does not exist");
        }

        binStorage.WarehouseSectionsId = dto.WarehouseSectionsId;
        binStorage.Row = dto.Row;

        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBinStorage(int id)
    {

        var binStorage = await _context.BinStorage.FindAsync(id);
        if (binStorage == null)
        {
            return NotFound($"Bin storage with ID {id} not found");
        }

        // add parent check

        _context.BinStorage.Remove(binStorage);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
