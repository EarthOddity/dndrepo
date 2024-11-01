using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[Route("api/[controller]")]
[ApiController]
public class ModeratorController: ControllerBase{
    
    private readonly ModeratorService _moderatorService;

    public ModeratorController(ModeratorService moderatorService){
        _moderatorService = moderatorService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Moderator>>> GetModerators(){
        var moderators = await _moderatorService.GetAllModerators();
        return Ok(moderators);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Moderator>> GetModerator(int id){
        var moderator = await _moderatorService.GetModeratorById(id);
        if(moderator == null){
            return NotFound();
        }
        return Ok(moderator);
    }

    [HttpPost]
    public async Task<ActionResult<Moderator>> AddModerator(Moderator moderator){
        await _moderatorService.AddModerator(moderator);
        return CreatedAtAction(nameof(GetModerator), new {id = moderator.id}, moderator);
    }

    /*[HttpPost("{moderatorId}/ban-review/{reviewId}")]
    public async Task<ActionResult> BanReview(int id, Review review){
        await _moderatorService.BanReview(id, review);
        return NoContent();
    }*/

    [HttpPut("{id}/assignSection")]
    public async Task<ActionResult> AssignSection(int id, [FromBody] string section){
        await _moderatorService.AssignSection(id, section);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteModerator(int id){
        await _moderatorService.deleteModerator(id);
        return NoContent();
    }

}