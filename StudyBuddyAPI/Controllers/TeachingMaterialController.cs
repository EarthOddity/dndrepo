using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("api/[controller]")]
public class TeachingMaterialController(ITeachingMaterialService _teachingMaterialService) : ControllerBase
{
    /* private readonly TeachingMaterialService _teachingMaterialService;

    public TeachingMaterialController(TeachingMaterialService teachingMaterialService)
    {
        _teachingMaterialService = teachingMaterialService;
    }
    */

    [HttpGet]
    public async Task<ActionResult<List<TeachingMaterial>>> GetAllMaterials()
    {
        return Ok(await _teachingMaterialService.GetAllMaterials());
        return Ok(await _teachingMaterialService.GetAllMaterials());
    }
    [HttpGet("title/{title}")]
    public async Task<ActionResult<List<TeachingMaterial>>> GetMaterialByTitle(string title)
    {
        var material = await _teachingMaterialService.GetMaterialByTitle(title);
        return Ok(material);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TeachingMaterial>> GetMaterialById(int id)
    {
        var material = await _teachingMaterialService.GetMaterialById(id);
        if (material == null)
            return NotFound();

        return Ok(material);
    }


    [HttpPost]
    public async Task<ActionResult<TeachingMaterial>> CreateMaterial(TeachingMaterial material)
    {
        if (material == null)
        {
            return BadRequest("Teaching material data is required.");
        }
        await _teachingMaterialService.CreateTeachingMaterial(material);
        return CreatedAtAction(nameof(GetMaterialById), new { id = material.id }, material);
    }

    [HttpPut("{title}")]
    public async Task<IActionResult> UpdateMaterial(int id, TeachingMaterial updatedMaterial)
    {
        var success = await _teachingMaterialService.UpdateMaterial(id, updatedMaterial.description, updatedMaterial.isApproved, updatedMaterial.author);
        if (!success)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{title}")]
    public async Task<IActionResult> DeleteMaterial(int id)
    {
        var success = await _teachingMaterialService.DeleteMaterial(id);
        if (!success)
            return NotFound();

        return NoContent();
    }

    [HttpGet("saved/{userId}")]
    public async Task<ActionResult<IEnumerable<TeachingMaterial>>> GetSavedMaterialsByUserId(int userId)
    {
        var materials = await _teachingMaterialService.GetSavedMaterialsByUserId(userId);
        if (materials == null)
        {
            return NotFound();
        }
        return Ok(materials);
    }

    [HttpPost("toggle-save")]
    public async Task<IActionResult> ToggleSaveMaterial(int userId, int materialId)
    {
        var success = await _teachingMaterialService.ToggleSaveMaterial(userId, materialId);
        if (!success)
        {
            return BadRequest("Failed to toggle save state.");
        }
        return Ok();
    }

    [HttpGet("search/{searchTerm}")]
    public async Task<ActionResult<IEnumerable<string>>> SearchTeachingMaterials(string searchTerm)
    {
        var materials = await _teachingMaterialService.SearchTeachingMaterials(searchTerm);
        return Ok(materials);
    }

}


