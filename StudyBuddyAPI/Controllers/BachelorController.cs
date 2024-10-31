using Microsoft.AspNetCore.Mvc;
using StudyBuddyAPI.Services;
using StudyBuddyAPI.Models;


namespace StudyBuddyAPI.Services
{
    [ApiController]
    [Route("api/[controller]")]

    public class BachelorController : ControllerBase
    {
        private BachelorService _bachelorService;

        public BachelorController(BachelorService bachelorService)
        {
            _bachelorService = bachelorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bachelor>>> GetBachelors()
        {
            var bachelors = await _bachelorService.GetAllBachelors();
            return Ok(bachelors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Bachelor>> GetBachelor(int id)
        {
            var bachelor = await _bachelorService.GetBachelorById(id);
            if (bachelor == null)
            {
                return NotFound();
            }
            return Ok(bachelor);
        }

        [HttpPost]
        public async Task<ActionResult<Bachelor>> CreateBachelor(Bachelor bachelor)
        {
            var newBachelor = await _bachelorService.CreateBachelor(bachelor);
            return CreatedAtAction(nameof(GetBachelor), new { id = newBachelor.id }, newBachelor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBachelor(int id, Bachelor bachelor)
        {
            await _bachelorService.UpdateBachelor(id, bachelor);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBachelor(int id)
        {
            var deleted = await _bachelorService.DeleteBachelor(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPost("{bachelorId}/subjects")]
        public async Task<IActionResult> AddSubject(int bachelorId, Subject @subject)
        {
            var added = await _bachelorService.AddSubjectToBachelor(bachelorId, @subject);
            if (!added)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpGet("{bachelorId}/subjects")]
        public async Task<IActionResult> GetSubjects(int bachelorId)
        {
            var subjects = await _bachelorService.GetSubjectsByBachelorId(bachelorId);
            return Ok(subjects);
        }
    }
}