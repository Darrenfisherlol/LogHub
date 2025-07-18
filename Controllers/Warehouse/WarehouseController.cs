using LogHubStart.Data;
using LogHubStart.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LogHubStart.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WarehousesController : ControllerBase
{
    private readonly AppDbContext _context;

    public WarehousesController(AppDbContext context)
    {
        _context = context;
    }

    //
    // RESTCRUD
    //

    [HttpGet]
    public async Task<IEnumerable<Warehouse>> GetWarehouses()
    {
        var warehouses = await _context.Warehouse.ToListAsync();
        return warehouses;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Warehouse>> GetWarehouse(int id)
    {
        var warehouse = await _context.Warehouse.FindAsync(id);

        if (warehouse == null)
        {
            return NotFound();
        }

        return warehouse;
    }

    [HttpPost]
    public async Task<ActionResult<Warehouse>> PostWarehouse(Warehouse warehouse)
    {
        if (warehouse is null)
        {
            return BadRequest();
        }

        Warehouse addWarehouse = new Warehouse
        {
            WarehouseName = warehouse.WarehouseName,
            Address = warehouse.Address,
            State = warehouse.State,
            Country = warehouse.Country,
            ZipCode = warehouse.ZipCode,
            OwnerName = warehouse.OwnerName,
            Phone = warehouse.Phone,
            Email = warehouse.Email,
            CreatedBy = warehouse.CreatedBy,
            CreatedDate = warehouse.CreatedDate,
            UpdatedBy = warehouse.UpdatedBy,
            UpdateDate = warehouse.UpdateDate,
        };

        _context.Warehouse.AddAsync(addWarehouse);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetWarehouse), new { id = warehouse.WarehouseId });
    }

    [HttpPut("{id}")]
    // overposting attacks
    // dto
    public async Task<IActionResult> PutWarehouse(int id, Warehouse updateWarehouse)
    {
        if (id != updateWarehouse.WarehouseId)
        {
            return BadRequest();
        }

        _context.Entry(updateWarehouse).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!WarehouseExists(id))
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
    public async Task<IActionResult> DeleteWarehouse(int id)
    {
        var warehouseExists = WarehouseExists(id);
        if (!warehouseExists)
        {
            return NotFound();
        }

        var warehouse = await _context.Warehouse.FindAsync(id);
        _context.Warehouse.Remove(warehouse);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // Logic
    public bool WarehouseExists(int id)
    {
        var doesWarehouseExist = _context.Warehouse.Any(e => e.WarehouseId == id);
        return doesWarehouseExist;
    }
}
