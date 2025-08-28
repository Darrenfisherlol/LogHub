using LogHubStart.Data;
using LogHubStart.DTOs;
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
    
    [HttpGet]
    public async Task<IEnumerable<Warehouse>> GetWarehouses()
    {
        //
        // Does the user have auth
        // Limit per linq ~ how many get pushed to frontend ~ what if 100000 warehouses
        //

        var warehouses = await _context.Warehouse.ToListAsync();
        return warehouses;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Warehouse>> GetWarehouse(int id)
    {
        //
        // Does the user have auth
        //
        
        var warehouse = await _context.Warehouse.FindAsync(id);

        if (warehouse == null)
        {
            return NotFound();
        }

        return warehouse;
    }

    [HttpPost]
    public async Task<ActionResult> CreateWarehouse([FromBody] CreateWarehouseDTO warehouseDto)
    {
        //
        // does employee have permission
        // is the address a real address 
        //
        
        if (warehouseDto is null)
        {
            return BadRequest();
        }
        
        var warehouse = new Warehouse
        {
            WarehouseName = warehouseDto.WarehouseName,
            Address = warehouseDto.Address,
            State = warehouseDto.State,
            Country = warehouseDto.Country,
            ZipCode = warehouseDto.ZipCode,
            OwnerName = warehouseDto.OwnerName,
            Phone = warehouseDto.Phone,
            Email = warehouseDto.Email,
            // get from Get from JWT/User
            // CreatedBy = GetEmployeeId(), 
            CreatedBy = 1, 
            CreatedDate = DateTime.UtcNow,
            // get from Get from JWT/User
            // UpdatedBy = GetEmployeeId(), 
            UpdatedBy = 1,
            UpdateDate = DateTime.UtcNow
            
        };
            
        await _context.Warehouse.AddAsync(warehouse);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetWarehouse), new { id = warehouse.WarehouseId });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutWarehouse(int id, [FromBody] UpdateWarehouseDTO dto)
    {
        
        //
        // Does user have auth to update a warehouse
        // Validate data from DTO
        //
        
        var warehouseExisting = await _context.Warehouse.FindAsync(dto.WarehouseId);

        if (warehouseExisting == null)
        {
            return BadRequest("ID in URL and body do not match.");
        }
        
        warehouseExisting.WarehouseName = dto.WarehouseName;
        warehouseExisting.Address = dto.Address;
        warehouseExisting.State = dto.State;
        warehouseExisting.Country = dto.Country;
        warehouseExisting.ZipCode = dto.ZipCode;
        warehouseExisting.OwnerName = dto.OwnerName;
        warehouseExisting.Phone = dto.Phone;
        warehouseExisting.Email = dto.Email;
        // warehouseExisting.UpdatedBy = GetEmployeeId();
        warehouseExisting.UpdatedBy = 1;
        warehouseExisting.UpdateDate = DateTime.UtcNow;
        
        await _context.SaveChangesAsync();
        
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteWarehouse(int id)
    {
        //
        // user input id is not null
        // user permission to delete that warehouse
        //
        
        var warehouse = await _context.Warehouse.FindAsync(id);
        if (warehouse == null)
        {
            return NotFound();
        }
        
        var warehouseSection = await _context.WarehouseSection.AnyAsync(x => x.WarehouseId == id);
        if (warehouseSection)
        {
            return BadRequest("Cannot delete a Warehouse since it has Warehouse section(s) exists");
        }

        _context.Warehouse.Remove(warehouse);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
