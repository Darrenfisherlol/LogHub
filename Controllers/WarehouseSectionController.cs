using LogHubStart.Data;
using LogHubStart.Models;
using LogHubStart.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LogHubStart.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WarehouseSectionController : ControllerBase
{
    private readonly IWarehouseSectionRepository _WarehouseSectionRepository;
    
    public WarehouseSectionController(IWarehouseSectionRepository WarehouseSectionRepository)
    {
        _WarehouseSectionRepository = WarehouseSectionRepository;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<WarehouseSection>>> GetAllWarehouseSections()
    {
        var sections = await _WarehouseSectionRepository.GetAllWarehouseSectionsAsync();
        return Ok(sections);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<WarehouseSection>> GetWarehouseSection(int id)
    {

        WarehouseSection warehouseSection = await _WarehouseSectionRepository.GetWarehouseSectionByIdAsync(id);

        if (warehouseSection == null)
        {
            return NotFound();
        }
        
        return warehouseSection;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutWarehouseSection(int id, WarehouseSection warehouseSection)
    {
        if (id != warehouseSection.WarehouseSectionId)
        {
            return BadRequest();
        }

        if (!await _WarehouseSectionRepository.WarehouseSectionExistsAsync(id))
        {
            return NotFound();
        }
        
        await _WarehouseSectionRepository.UpdateWarehouseSectionAsync(warehouseSection);
        
        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<WarehouseSection>> PostWarehouseSection(WarehouseSection warehouseSection)
    {
        if (warehouseSection is null)
        {
            return Problem("warehouseSection is null.");
        }

        _WarehouseSectionRepository.AddWarehouseSectionAsync(warehouseSection);
        
        
        return CreatedAtAction("GetWarehouseSection", new { id = warehouseSection.WarehouseSectionId });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteWarehouseSection(int id)
    {
        await _WarehouseSectionRepository.DeleteWarehouseSectionAsync(id);
        return NoContent();
    }

    // business logic  

    public Task<bool> WarehouseSectionExists(int id)
    {
        return _WarehouseSectionRepository.WarehouseSectionExistsAsync(id);
    }
}
