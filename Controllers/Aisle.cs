using LogHubStart.Models;
using LogHubStart.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LogHubStart.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AisleSectionController : ControllerBase
{
    private readonly IAisleSectionRepository _AisleSectionRepository;

    public AisleSectionController(IAisleSectionRepository AisleSectionRepository)
    {
        _AisleSectionRepository = AisleSectionRepository;
    }

    // GET: api/AisleSection
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AisleSection>>> GetAisleSections()
    {
        var AisleSections = await _AisleSectionRepository.GetAllAisleSectionsAsync();
        return Ok(AisleSections);
    }

    // GET: api/AisleSection/5
    [HttpGet("{id}")]
    public async Task<ActionResult<AisleSection>> GetAisleSection(int id)
    {
        var AisleSection = await _AisleSectionRepository.GetAisleSectionByIdAsync(id);
        if (AisleSection == null)
        {
            return NotFound();
        }

        return Ok(AisleSection);
    }

    // POST: api/AisleSection
    [HttpPost]
    public async Task<ActionResult<AisleSection>> PostAisleSection(AisleSection AisleSection)
    {
        await _AisleSectionRepository.AddAisleSectionAsync(AisleSection);
        return CreatedAtAction(nameof(GetAisleSection), new { id = AisleSection.AisleSectionID }, AisleSection);
    }

    // PUT: api/AisleSection/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAisleSection(int id, AisleSection AisleSection)
    {
        if (id != AisleSection.AisleSectionID)
        {
            return BadRequest();
        }

        if (!await _AisleSectionRepository.AisleSectionExistsAsync(id))
        {
            return NotFound();
        }
        
        await _AisleSectionRepository.UpdateAisleSectionAsync(AisleSection);

        return NoContent();
    }

    // DELETE: api/AisleSection/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAisleSection(int id)
    {
        if (!await _AisleSectionRepository.AisleSectionExistsAsync(id))
        {
            return NotFound();
        }

        await _AisleSectionRepository.DeleteAisleSectionAsync(id);
        return NoContent();
    }
}
