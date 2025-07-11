using LogHubStart.Models;
using LogHubStart.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LogHubStart.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BinPositionController : ControllerBase
{
    private readonly IBinPositionRepository _BinPositionRepository;

    public BinPositionController(IBinPositionRepository BinPositionRepository)
    {
        _BinPositionRepository = BinPositionRepository;
    }

    // GET: api/BinPosition
    [HttpGet]
    public async Task<ActionResult<IEnumerable<BinPosition>>> GetBinPositions()
    {
        var BinPositions = await _BinPositionRepository.GetAllBinPositionsAsync();
        return Ok(BinPositions);
    }

    // GET: api/BinPosition/5
    [HttpGet("{id}")]
    public async Task<ActionResult<BinPosition>> GetBinPosition(int id)
    {
        var BinPosition = await _BinPositionRepository.GetBinPositionByIdAsync(id);
        if (BinPosition == null)
        {
            return NotFound();
        }

        return Ok(BinPosition);
    }

    // POST: api/BinPosition
    [HttpPost]
    public async Task<ActionResult<BinPosition>> PostBinPosition(BinPosition BinPosition)
    {
        await _BinPositionRepository.AddBinPositionAsync(BinPosition);
        return CreatedAtAction(nameof(GetBinPosition), new { id = BinPosition.BinPositionID }, BinPosition);
    }

    // PUT: api/BinPosition/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutBinPosition(int id, BinPosition BinPosition)
    {
        if (id != BinPosition.BinPositionID)
        {
            return BadRequest();
        }

        if (!await _BinPositionRepository.BinPositionExistsAsync(id))
        {
            return NotFound();
        }
        
        await _BinPositionRepository.UpdateBinPositionAsync(BinPosition);

        return NoContent();
    }

    // DELETE: api/BinPosition/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBinPosition(int id)
    {
        if (!await _BinPositionRepository.BinPositionExistsAsync(id))
        {
            return NotFound();
        }

        await _BinPositionRepository.DeleteBinPositionAsync(id);
        return NoContent();
    }
}
