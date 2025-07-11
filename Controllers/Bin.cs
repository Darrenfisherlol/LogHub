using LogHubStart.Models;
using LogHubStart.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LogHubStart.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StraightLineController : ControllerBase
{
    private readonly IStraightLineRepository _straightLineRepository;

    public StraightLineController(IStraightLineRepository straightLineRepository)
    {
        _straightLineRepository = straightLineRepository;
    }

    // GET: api/StraightLine
    [HttpGet]
    public async Task<ActionResult<IEnumerable<StraightLine>>> GetStraightLines()
    {
        var straightLines = await _straightLineRepository.GetAllStraightLinesAsync();
        return Ok(straightLines);
    }

    // GET: api/StraightLine/5
    [HttpGet("{id}")]
    public async Task<ActionResult<StraightLine>> GetStraightLine(int id)
    {
        var straightLine = await _straightLineRepository.GetStraightLineByIdAsync(id);
        if (straightLine == null)
        {
            return NotFound();
        }

        return Ok(straightLine);
    }

    // POST: api/StraightLine
    [HttpPost]
    public async Task<ActionResult<StraightLine>> PostStraightLine(StraightLine straightLine)
    {
        await _straightLineRepository.AddStraightLineAsync(straightLine);
        return CreatedAtAction(nameof(GetStraightLine), new { id = straightLine.StraightLineID }, straightLine);
    }

    // PUT: api/StraightLine/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutStraightLine(int id, StraightLine straightLine)
    {
        if (id != straightLine.StraightLineID)
        {
            return BadRequest();
        }

        if (!await _straightLineRepository.StraightLineExistsAsync(id))
        {
            return NotFound();
        }
        
        await _straightLineRepository.UpdateStraightLineAsync(straightLine);

        return NoContent();
    }

    // DELETE: api/StraightLine/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStraightLine(int id)
    {
        if (!await _straightLineRepository.StraightLineExistsAsync(id))
        {
            return NotFound();
        }

        await _straightLineRepository.DeleteStraightLineAsync(id);
        return NoContent();
    }
}
