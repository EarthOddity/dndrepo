using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[ApiController]
[Route("api/[controller]")]

public class SubjectController : ControllerBase
{
    private readonly SubjectService _subjectService;

    public SubjectController()
    {
        _subjectService = new SubjectService();
    }

    [HttpGet]
    public ActionResult<IEnumerable<Subject>> GetAllSubjects()
    {
        var subjects = _subjectService.GetAllSubjects();
        return Ok(subjects);
    }

    [HttpGet("{id}")]
    public ActionResult<Subject> GetSubjectById(int id)
    {
        var subject = _subjectService.GetSubjectById(id);
        if (subject == null)
        {
            return NotFound();
        }
        return Ok(subject);
    }

    [HttpGet("name/{name}")]
    public ActionResult<Subject> GetSubjectByName(string name)
    {
        var subject = _subjectService.GetSubjectByName(name);
        if (subject == null)
        {
            return NotFound();
        }
        return Ok(subject);
    }

    [HttpPost]
    public ActionResult<Subject> AddSubject(Subject subject)
    {
        _subjectService.AddSubject(subject);
        return CreatedAtAction(nameof(GetSubjectByName), new { name = subject.Name }, subject);
    }

    [HttpPut("{id}")]
    public ActionResult UpdateSubject(Subject subject)
    {
        _subjectService.UpdateSubject(subject);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteSubject(int Id)
    {
        bool isDeleted = _subjectService.DeleteSubject(Id);
        if (!isDeleted)
        {
            return NotFound();
        }
        return NoContent();
    }
}
