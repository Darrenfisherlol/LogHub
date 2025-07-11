using LogHubStart.Models;
using LogHubStart.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LogHubStart.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AisleSectionPositionController : ControllerBase
{
    private readonly IAisleSectionPositionRepository _AisleSectionPositionRepository;

    public AisleSectionPositionController(IAisleSectionPositionRepository AisleSectionPositionRepository)
    {
        _AisleSectionPositionRepository = AisleSectionPositionRepository;
    }

    // GET: api/AisleSectionPosition
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AisleSectionPosition>>> GetAisleSectionPositions()
    {
        var AisleSectionPositions = await _AisleSectionPositionRepository.GetAllAisleSectionPositionsAsync();
        return Ok(AisleSectionPositions);
    }

    // GET: api/AisleSectionPosition/5
    [HttpGet("{id}")]
    public async Task<ActionResult<AisleSectionPosition>> GetAisleSectionPosition(int id)
    {
        var AisleSectionPosition = await _AisleSectionPositionRepository.GetAisleSectionPositionByIdAsync(id);
        if (AisleSectionPosition == null)
        {
            return NotFound();
        }

        return Ok(AisleSectionPosition);
    }

    // POST: api/AisleSectionPosition
    [HttpPost]
    public async Task<ActionResult<AisleSectionPosition>> PostAisleSectionPosition(AisleSectionPosition AisleSectionPosition)
    {
        await _AisleSectionPositionRepository.AddAisleSectionPositionAsync(AisleSectionPosition);
        return CreatedAtAction(nameof(GetAisleSectionPosition), new { id = AisleSectionPosition.AisleSectionPositionID }, AisleSectionPosition);
    }

    // PUT: api/AisleSectionPosition/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAisleSectionPosition(int id, AisleSectionPosition AisleSectionPosition)
    {
        if (id != AisleSectionPosition.AisleSectionPositionID)
        {
            return BadRequest();
        }

        if (!await _AisleSectionPositionRepository.AisleSectionPositionExistsAsync(id))
        {
            return NotFound();
        }
        
        await _AisleSectionPositionRepository.UpdateAisleSectionPositionAsync(AisleSectionPosition);

        return NoContent();
    }

    // DELETE: api/AisleSectionPosition/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAisleSectionPosition(int id)
    {
        if (!await _AisleSectionPositionRepository.AisleSectionPositionExistsAsync(id))
        {
            return NotFound();
        }

        await _AisleSectionPositionRepository.DeleteAisleSectionPositionAsync(id);
        return NoContent();
    }
}
