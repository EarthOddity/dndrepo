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

 /*    [HttpGet("search/{searchTerm}")]
    public async Task<ActionResult<IEnumerable<string>>> SearchTeachingMaterials(string searchTerm)
    {
        var materials = await _teachingMaterialService.SearchTeachingMaterials(searchTerm);
        return Ok(materials);
    } */
}

using Microsoft.AspNetCore.Mvc;
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
        [HttpGet("title/{title}")]
        public ActionResult<List<TeachingMaterial>> GetMaterialByTitle(string title){
            var material = _teachingMaterialService.GetMaterialByTitle(title);
            return Ok(material);
        }

        [HttpGet("{id}")]
        public ActionResult<TeachingMaterial> GetMaterialById(int id)
        {
            var material = _teachingMaterialService.GetMaterialById(id);
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
            await _teachingMaterialService.CreateMaterial(material);
            return CreatedAtAction(nameof(GetMaterialById), new { id = material.id }, material);
        }

        // [HttpPut("{title}")]
        // public ActionResult UpdateMaterial(int id, [FromBody] TeachingMaterial updatedMaterial)
        // {
        //     var success = _teachingMaterialService.UpdateMaterial(id, updatedMaterial.description, updatedMaterial.isApproved, updatedMaterial.author);
        //     if (!success)
        //         return NotFound();

        //     return NoContent();
        // }

        [HttpDelete("{title}")]
        public ActionResult DeleteMaterial(int id)
        {
            var success = _teachingMaterialService.DeleteMaterial(id);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }


