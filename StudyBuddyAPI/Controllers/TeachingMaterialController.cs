using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("api/[controller]")]
public class TeachingMaterialController(ITeachingMaterialService _teachingMaterialService) : ControllerBase
{
    private readonly TeachingMaterialService _teachingMaterialService;

    public TeachingMaterialController(TeachingMaterialService teachingMaterialService)
    {
        _teachingMaterialService = teachingMaterialService;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TeachingMaterial>>> GetAllMaterials()
    {
        try
        {
            var materials = await _teachingMaterialService.GetAllMaterials();
            return Ok(materials);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("title/{title}")]
    public async Task<ActionResult<IEnumerable<TeachingMaterial>>> GetMaterialByTitle(string title)
    {
        var materials = await _teachingMaterialService.GetMaterialByTitle(title);
        if (!materials.Any())
            return NotFound($"No materials found with title containing '{title}'");
        return Ok(materials);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TeachingMaterial>> GetMaterialById(int id)
    {
        var material = await _teachingMaterialService.GetMaterialById(id);
        if (material == null)
            return NotFound($"Material with ID {id} not found");
        return Ok(material);
    }

    [HttpPost]
    public async Task<ActionResult<TeachingMaterial>> CreateMaterial(TeachingMaterial material)
    {
        if (material == null)
            return BadRequest("Material cannot be null");

        var createdMaterial = await _teachingMaterialService.CreateTeachingMaterial(material);
        return CreatedAtAction(nameof(GetMaterialById), new { id = createdMaterial.id }, createdMaterial);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateMaterial(int id, TeachingMaterial material)
    {
        var success = await _teachingMaterialService.UpdateMaterial(id, material.description, material.isApproved, material.author);
        if (!success)
            return NotFound($"Material with ID {id} not found");
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMaterial(int id)
    {
        var success = await _teachingMaterialService.DeleteMaterial(id);
        if (!success)
            return NotFound($"Material with ID {id} not found");
        return NoContent();
    }

    [HttpGet("author")]
    public async Task<ActionResult<TeachingMaterial>> GetMaterialByAuthor([FromQuery] Student author)
    {
        var material = await _teachingMaterialService.GetMaterialByAuthor(author);
        if (material == null)
            return NotFound("No materials found for this author");
        return Ok(material);
    }

    [HttpGet("saved/{userId}")]
    public async Task<ActionResult<IEnumerable<TeachingMaterial>>> GetSavedMaterials(int userId)
    {
        var materials = await _teachingMaterialService.GetSavedMaterialsByUserId(userId);
        if (!materials.Any())
            return NotFound($"No saved materials found for user {userId}");
        return Ok(materials);
    }

    [HttpPost("toggle-save")]
    public async Task<IActionResult> ToggleSaveMaterial([FromQuery] int userId, [FromQuery] int materialId)
    {
        var success = await _teachingMaterialService.ToggleSaveMaterial(userId, materialId);
        if (!success)
            return BadRequest("Failed to toggle save state");
        return Ok();
    }

    [HttpGet("search/{searchTerm}")]
    public async Task<ActionResult<IEnumerable<TeachingMaterial>>> SearchMaterials(string searchTerm)
    {
        var materials = await _teachingMaterialService.SearchTeachingMaterials(searchTerm);
        return Ok(materials);
    }
    
      

}


