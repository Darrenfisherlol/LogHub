using Microsoft.AspNetCore.Mvc;
using LogHubStart.Data;
using LogHubStart.Models;
using Microsoft.EntityFrameworkCore;

namespace LogHubStart.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SupplierController : ControllerBase
{
    private readonly AppDbContext _context;

    public SupplierController(AppDbContext context)
    {
        _context = context;
    }

    //
    // RESTCRUD
    //
    
    [HttpGet]
    public async Task<IEnumerable<Supplier>> GetSuppliers()
    {
        var supplier = await _context.Supplier.ToListAsync();
        return supplier;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Supplier>> GetSupplier(int id)
    {
        var supplier = await _context.Supplier.FindAsync(id);

        if (supplier == null)
        {
            return NotFound();
        }

        return supplier;
    }

    [HttpPost]
    // overposting attacks
    // dto
    public async Task<ActionResult<Supplier>> PostSupplier(Supplier supplier)
    {
        if (supplier is null)
        {
            return BadRequest();
        }
        
        
        Supplier addSupplier = new Supplier
        {
            SupplierName = Supplier.Name,
            Email = Supplier.Email,
            Phone = Supplier.Phone
        };

        await _context.Supplier.AddAsync(addSupplier);
        await _context.SaveChangesAsync();
        
        return CreatedAtAction(nameof(GetSupplier), new { id = Supplier.SupplierId });
    }

    [HttpPut("{id}")]
    // overposting attacks
    // dto
    public async Task<IActionResult> PutSupplier(int id, Supplier updateSupplier)
    {
        if (id != updateSupplier.SupplierId)
        {
            return BadRequest();
        }
        
        _context.Entry(updateSupplier).State = EntityState.Modified;
        
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!SupplierExists(id))
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
    public async Task<IActionResult> DeleteSupplier(int id)
    {
        var supplierExists = SupplierExists(id);
        if (!supplierExists)
        {
            return NotFound();
        }
        
        var supplier = await _context.Supplier.FindAsync(id);
        _context.Supplier.Remove(supplier);
        await _context.SaveChangesAsync();
        
        return NoContent();
    }
    
    // Logic
    public bool SupplierExists(int id)
    {
        var doesSupplierExist = _context.Supplier
            .Any(e => e.SupplierId == id);
        return doesSupplierExist;
    }
}
