using Microsoft.AspNetCore.Mvc;
using StudyBuddyAPI;
using StudyBuddyAPI.Services; 
using System.Collections.Generic;

namespace StudyBuddyAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeachingMaterialController : ControllerBase
    {
        private readonly TeachingMaterialService _teachingMaterialService;

        // Constructor Injection
        public TeachingMaterialController(TeachingMaterialService teachingMaterialService)
        {
            _teachingMaterialService = teachingMaterialService;
        }

        // GET: api/TeachingMaterial
        [HttpGet]
        public ActionResult<List<TeachingMaterial>> GetAllMaterials()
        {
            return Ok(_teachingMaterialService.GetAllMaterials());
        }

        // GET: api/TeachingMaterial/{title}
        [HttpGet("{title}")]
        public ActionResult<TeachingMaterial> GetMaterialByTitle(string title)
        {
            var material = _teachingMaterialService.GetMaterialByTitle(title);
            if (material == null)
                return NotFound();

            return Ok(material);
        }

        // POST: api/TeachingMaterial
        [HttpPost]
        public ActionResult<TeachingMaterial> AddMaterial([FromBody] TeachingMaterial material)
        {
            _teachingMaterialService.AddMaterial(material);
            return CreatedAtAction(nameof(GetMaterialByTitle), new { title = material.Title }, material);
        }

        // PUT: api/TeachingMaterial/{title}
        [HttpPut("{title}")]
        public ActionResult UpdateMaterial(string title, [FromBody] TeachingMaterial updatedMaterial)
        {
            var success = _teachingMaterialService.UpdateMaterial(title, updatedMaterial.Description, updatedMaterial.IsApproved, updatedMaterial.Author);
            if (!success)
                return NotFound();

            return NoContent();
        }

        // DELETE: api/TeachingMaterial/{title}
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
