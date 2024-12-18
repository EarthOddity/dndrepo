using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("api/[controller]")]

public class BachelorController : ControllerBase
{
    private IBachelorService _bachelorService;

    public BachelorController(IBachelorService bachelorService)
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
        return CreatedAtAction(nameof(GetBachelor), new { id = newBachelor.Id }, newBachelor);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBachelor(int Id, Bachelor Bachelor)
    {
        await _bachelorService.UpdateBachelor(Id, Bachelor);
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

    [HttpPost("{bachelorId}/add-subject/{subjectId}")]
    public async Task<IActionResult> AddSubject(int bachelorId, int subjectId)
    {
        var added = await _bachelorService.AddSubjectToBachelor(bachelorId, subjectId);
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

    [HttpGet("student/{studentId}")]
    public async Task<ActionResult<Bachelor>> GetBachelorByStudentId(int studentId)
    {
        var bachelor = await _bachelorService.GetBachelorByStudentId(studentId);
        if (bachelor == null)
        {
            return NotFound();
        }
        return Ok(bachelor);
    }

    [HttpGet("search/{searchTerm}")]
    public async Task<ActionResult<IEnumerable<string>>> SearchBachelors(string searchTerm)
    {
        var bachelors = await _bachelorService.SearchBachelors(searchTerm);
        return Ok(bachelors);
    }
}