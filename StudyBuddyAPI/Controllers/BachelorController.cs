using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("api/[controller]")]

public class BachelorController : ControllerBase
{
    private readonly BachelorService _bachelorService;

    public BachelorController(BachelorService bachelorService)
    {
        _bachelorService = bachelorService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Bachelor>>> GetBachelors()
    {
        try
        {
            var bachelors = await _bachelorService.GetAllBachelors();
            return Ok(bachelors);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Bachelor>> GetBachelor(int id)
    {
        try
        {
            var bachelor = await _bachelorService.GetBachelorById(id);
            if (bachelor == null)
                return NotFound($"Bachelor with ID {id} not found");
            return Ok(bachelor);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
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