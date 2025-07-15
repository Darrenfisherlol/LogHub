using Microsoft.AspNetCore.Mvc;
using LogHubStart.Data;
using LogHubStart.Models;
using Microsoft.EntityFrameworkCore;

namespace LogHubStart.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BinController : ControllerBase
{
    private readonly AppDbContext _context;

    public BinController(AppDbContext context)
    {
        _context = context;
    }

    //
    // RESTCRUD
    //
    
    [HttpGet]
    public async Task<IEnumerable<Bin>> GetBins()
    {
        var bins = await _context.Bin.ToListAsync();
        return bins;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Bin>> GetBin(int id)
    {
        var bin = await _context.Bin.FindAsync(id);

        if (bin == null)
        {
            return NotFound();
        }

        return bin;
    }

    [HttpPost]
    // overposting attacks
    // dto
    public async Task<ActionResult<Bin>> PostBin(Bin bin)
    {
        if (bin is null)
        {
            return BadRequest();
        }

        Bin binUpdate = new Bin
        {
            BinStorageId = bin.StorageId,
            BinStorage = bin.BinStorage,
            BinCapacity = bin.Capacity,
            Height = bin.Height,
            Width = bin.Width,
            Length = bin.Length
        };

        _context.Add(binUpdate);
        await _context.SaveChangesAsync();
        
        return CreatedAtAction("GetBin", new { id = bin.BinId });
    }

    [HttpPut("{id}")]
    // overposting attacks
    // dto
    public async Task<IActionResult> PutBin(int id, Bin updateBin)
    {
        if (id != updateBin.BinId)
        {
            return BadRequest();
        }
        
        _context.Entry(updateBin).State = EntityState.Modified;
        
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!BinExists(id))
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
    public async Task<IActionResult> DeleteBin(int id)
    {
        var binExists = BinExists(id);
        if (!binExists)
        {
            return NotFound();
        }
        
        var bin = await _context.Bin.FindAsync(id);
        _context.Bin.Remove(bin);
        await _context.SaveChangesAsync();
        
        return NoContent();
    }
    
    // Logic
    public bool BinExists(int id)
    {
        var doesBinExist = _context.Bin
            .Any(e => e.BinId == id);
        return doesBinExist;
    }
}
