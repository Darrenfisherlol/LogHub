using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using LogHubStart.Models;
using LogHubStart.Repositories; 

[Route("[controller]")]
[ApiController]
public class WarehousesController : ControllerBase
{
    private readonly IWarehouseRepository _warehouseRepository;

    public WarehousesController(IWarehouseRepository warehouseRepository)
    {
        _warehouseRepository = warehouseRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Warehouse>>> GetWarehouses()
    {
        var warehouses = await _warehouseRepository.GetAllWarehousesAsync();
        return Ok(warehouses);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Warehouse>> GetWarehouse(int id)
    {
        var warehouse = await _warehouseRepository.GetWarehouseByIdAsync(id);

        if (warehouse == null)
        {
            return NotFound();
        }

        return Ok(warehouse);
    }

    [HttpPost]
    public async Task<ActionResult<Warehouse>> PostWarehouse(Warehouse CreateWarehouse)
    {
        await _warehouseRepository.AddWarehouseAsync(CreateWarehouse);

        return CreatedAtAction(nameof(GetWarehouse), new { id = CreateWarehouse.WarehouseId }, CreateWarehouse);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutWarehouse(int id, Warehouse updateWarehouse)
    {
        if (id != updateWarehouse.WarehouseId)
        {
            return BadRequest();
        }

        var existingWarehouse = await _warehouseRepository.GetWarehouseByIdAsync(id);
        if (existingWarehouse is null)
        {
            return NotFound();
        }

        // make sure works
        await _warehouseRepository.UpdateWarehouseAsync(updateWarehouse);

        return NoContent(); // 204 No Content for successful update - CONTENT UPDATED banner / popup
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteWarehouse(int id)
    {
        var warehouseExists = await _warehouseRepository.WarehouseExistsAsync(id);
        if (!warehouseExists)
        {
            return NotFound();
        }

        await _warehouseRepository.DeleteWarehouseAsync(id);
        return NoContent();
    }
}
