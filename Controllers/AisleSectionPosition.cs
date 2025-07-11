using LogHubStart.Models;
using LogHubStart.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LogHubStart.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IslandPositionController : ControllerBase
{
    private readonly IIslandPositionRepository _IslandPositionRepository;

    public IslandPositionController(IIslandPositionRepository IslandPositionRepository)
    {
        _IslandPositionRepository = IslandPositionRepository;
    }

    // GET: api/IslandPosition
    [HttpGet]
    public async Task<ActionResult<IEnumerable<IslandPosition>>> GetIslandPositions()
    {
        var IslandPositions = await _IslandPositionRepository.GetAllIslandPositionsAsync();
        return Ok(IslandPositions);
    }

    // GET: api/IslandPosition/5
    [HttpGet("{id}")]
    public async Task<ActionResult<IslandPosition>> GetIslandPosition(int id)
    {
        var IslandPosition = await _IslandPositionRepository.GetIslandPositionByIdAsync(id);
        if (IslandPosition == null)
        {
            return NotFound();
        }

        return Ok(IslandPosition);
    }

    // POST: api/IslandPosition
    [HttpPost]
    public async Task<ActionResult<IslandPosition>> PostIslandPosition(IslandPosition IslandPosition)
    {
        await _IslandPositionRepository.AddIslandPositionAsync(IslandPosition);
        return CreatedAtAction(nameof(GetIslandPosition), new { id = IslandPosition.IslandPositionID }, IslandPosition);
    }

    // PUT: api/IslandPosition/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutIslandPosition(int id, IslandPosition IslandPosition)
    {
        if (id != IslandPosition.IslandPositionID)
        {
            return BadRequest();
        }

        if (!await _IslandPositionRepository.IslandPositionExistsAsync(id))
        {
            return NotFound();
        }
        
        await _IslandPositionRepository.UpdateIslandPositionAsync(IslandPosition);

        return NoContent();
    }

    // DELETE: api/IslandPosition/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteIslandPosition(int id)
    {
        if (!await _IslandPositionRepository.IslandPositionExistsAsync(id))
        {
            return NotFound();
        }

        await _IslandPositionRepository.DeleteIslandPositionAsync(id);
        return NoContent();
    }
}
