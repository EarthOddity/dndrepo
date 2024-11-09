using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[ApiController]
[Route("api/[controller]")]

public class SubjectController(ISubjectService _subjectService) : ControllerBase
{
    /* private readonly SubjectService _subjectService;

    public SubjectController()
    {
        _subjectService = new SubjectService();
    } */

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Subject>>> GetAllSubjects()
    {
        var subjects = await _subjectService.GetAllSubjects();
        return Ok(subjects);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Subject>> GetSubjectById(int id)
    {
        var subject = await _subjectService.GetSubjectById(id);
        if (subject == null)
        {
            return NotFound();
        }
        return Ok(subject);
    }

    [HttpGet("name/{name}")]
    public async Task<ActionResult<Subject>> GetSubjectByName(string name)
    {
        var subject = await _subjectService.GetSubjectByName(name);
        if (subject == null)
        {
            return NotFound();
        }
        return Ok(subject);
    }

    [HttpPost]
    public async Task<ActionResult<Subject>> AddSubject(Subject subject)
    {
        await _subjectService.AddSubject(subject);
        return CreatedAtAction(nameof(GetSubjectByName), new { name = subject.name }, subject);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateSubject(Subject subject)
    {
        await _subjectService.UpdateSubject(subject);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteSubject(int id)
    {
        bool isDeleted = await _subjectService.DeleteSubject(id);
        if (!isDeleted)
        {
            return NotFound();
        }
        return NoContent();
    }
}
