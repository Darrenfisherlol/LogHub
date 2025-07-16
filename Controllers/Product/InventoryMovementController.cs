using LogHubStart.Data;
using LogHubStart.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LogHubStart.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InventoryMovementController : ControllerBase
{
    private readonly AppDbContext _context;

    public InventoryMovementController(AppDbContext context)
    {
        _context = context;
    }

    //
    // RESTCRUD
    //

    [HttpGet]
    public async Task<IEnumerable<InventoryMovement>> GetInventoryMovements()
    {
        var inventoryMovement = await _context.InventoryMovement.ToListAsync();
        return inventoryMovement;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<InventoryMovement>> GetInventoryMovement(int id)
    {
        var inventoryMovement = await _context.InventoryMovement.FindAsync(id);

        if (inventoryMovement == null)
        {
            return NotFound();
        }

        return inventoryMovement;
    }

    [HttpPost]
    // overposting attacks
    // dto
    public async Task<ActionResult<InventoryMovement>> PostInventoryMovement(
        InventoryMovement inventoryMovement
    )
    {
        if (inventoryMovement is null)
        {
            return BadRequest();
        }

        InventoryMovement addInventoryMovement = new InventoryMovement
        {
            ItemId = inventoryMovement.ItemId,
            Item = inventoryMovement.Item,
            FromProductLocationId = inventoryMovement.FromProductLocationId,
            FromItemLocation = inventoryMovement.FromItemLocation,
            ToProductLocationId = inventoryMovement.ToProductLocationId,
            ToItemLocation = inventoryMovement.ToItemLocation,
            OrderId = inventoryMovement.OrderId,
            Order = inventoryMovement.Order,
            MovementDate = inventoryMovement.MovementDate,
            MovementByEmployeeId = inventoryMovement.MovementByEmployeeId,
            MovementByEmployee = inventoryMovement.MovementByEmployee,
        };

        await _context.InventoryMovement.AddAsync(addInventoryMovement);
        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetInventoryMovement),
            new { id = inventoryMovement.InventoryMovementId }
        );
    }

    [HttpPut("{id}")]
    // overposting attacks
    // dto
    public async Task<IActionResult> PutInventoryMovement(
        int id,
        InventoryMovement updateInventoryMovement
    )
    {
        if (id != updateInventoryMovement.InventoryMovementId)
        {
            return BadRequest();
        }

        _context.Entry(updateInventoryMovement).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!InventoryMovementExists(id))
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
    public async Task<IActionResult> DeleteInventoryMovement(int id)
    {
        var inventoryMovementExists = InventoryMovementExists(id);
        if (!inventoryMovementExists)
        {
            return NotFound();
        }

        var inventoryMovement = await _context.InventoryMovement.FindAsync(id);
        _context.InventoryMovement.Remove(inventoryMovement);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // Logic
    public bool InventoryMovementExists(int id)
    {
        var doesInventoryMovementExist = _context.InventoryMovement.Any(e =>
            e.InventoryMovementId == id
        );
        return doesInventoryMovementExist;
    }
}
