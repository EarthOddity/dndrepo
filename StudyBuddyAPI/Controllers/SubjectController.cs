using Microsoft.AspNetCore.Mvc;
using StudyBuddyAPI.models;
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

    [HttpGet("{Name}")]
    public ActionResult<Subject> GetSubjectByName(int name)
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
        return CreatedAtAction(nameof(GetSubjectById), new { id = subject.Id }, subject);
    }

    [HttpPut]
    public ActionResult UpdateSubject(Subject subject)
    {
        _subjectService.UpdateSubject(subject);
        return NoContent();
    }

    [HttpDelete("{Name}")]
    public ActionResult DeleteSubject(string name)
    {
        bool isDeleted = _subjectService.DeleteSubject(id);
        if (!isDeleted)
        {
            return NotFound();
        }
        return NoContent();
    }
}
