using Microsoft.AspNetCore.Mvc;
using LogHubStart.Data;
using LogHubStart.Models;
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
    public async Task<ActionResult<BinStorage>> PostBinStorage(BinStorage binStorage)
    {
        if (binStorage is null)
        {
            return BadRequest();
        }
        
        BinStorage binStorageUpdate = new BinStorage
        {
            WarehouseSectionId = binStorage.WarehouseSectionId,
            WarehouseSection = binStorage.WarehouseSection,
            Row = binStorage.Row
        };

        await _context.AddAsync(binStorageUpdate);
        await _context.SaveChangesAsync();
        
        return CreatedAtAction("GetBinStorage", new { id = binStorage.BinStorageId });
    }

    [HttpPut("{id}")]
    // overposting attacks
    // dto
    public async Task<IActionResult> PutBinStorage(int id, BinStorage updateBinStorage)
    {
        if (id != updateBinStorage.BinStorageId)
        {
            return BadRequest();
        }
        
        _context.Entry(updateBinStorage).State = EntityState.Modified;
        
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!BinStorageExists(id))
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
    public async Task<IActionResult> DeleteBinStorage(int id)
    {
        var binStorageExists = BinStorageExists(id);
        if (!binStorageExists)
        {
            return NotFound();
        }
        
        var binStorage = await _context.BinStorage.FindAsync(id);
        _context.BinStorage.Remove(binStorage);
        await _context.SaveChangesAsync();
        
        return NoContent();
    }
    
    // Logic
    public bool BinStorageExists(int id)
    {
        var doesBinStorageExist = _context.BinStorage
            .Any(e => e.BinStorageId == id);
        return doesBinStorageExist;
    }
}
