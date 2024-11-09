using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[ApiController]
[Route("api/[controller]")]
public class TeachingMaterialController : ControllerBase
{
    private readonly TeachingMaterialService _teachingMaterialService;

    public TeachingMaterialController(TeachingMaterialService teachingMaterialService)
    {
        _teachingMaterialService = teachingMaterialService;
    }

    [HttpGet]
    public ActionResult<List<TeachingMaterial>> GetAllMaterials()
    {
        return Ok(_teachingMaterialService.GetAllMaterials());
    }

    [HttpGet("{title}")]
    public ActionResult<TeachingMaterial> GetMaterialByTitle(string title)
    {
        var material = _teachingMaterialService.GetMaterialByTitle(title);
        if (material == null)
            return NotFound();

        return Ok(material);
    }

    [HttpPost]
    public ActionResult<TeachingMaterial> AddMaterial([FromBody] TeachingMaterial material)
    {
        _teachingMaterialService.AddMaterial(material);
        return CreatedAtAction(nameof(GetMaterialByTitle), new { title = material.Title }, material);
    }

    [HttpPut("{title}")]
    public ActionResult UpdateMaterial(string title, [FromBody] TeachingMaterial updatedMaterial)
    {
        var success = _teachingMaterialService.UpdateMaterial(title, updatedMaterial.Description, updatedMaterial.IsApproved, updatedMaterial.Author);
        if (!success)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{title}")]
    public ActionResult DeleteMaterial(string title)
    {
        var success = _teachingMaterialService.DeleteMaterial(title);
        if (!success)
            return NotFound();

        return NoContent();
    }
}
}
