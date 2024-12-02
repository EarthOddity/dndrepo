
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


[ApiController]
[Route("api/[controller]")]

public class StudentController(IStudentService _studentService, ISBCalendarService _calendarService ) : ControllerBase
{
    //private readonly IStudentService _studentService;

   /*  public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    } */

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
    {
        var students = await _studentService.GetAllStudents();
        return Ok(students);

    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Student>> GetStudent(int id)
    {
        var student = await _studentService.GetStudentById(id);
        if (student == null)
        {
            return NotFound();
        }
        return Ok(student);
    }

    [HttpGet("name/{name}")]
    public async Task<ActionResult<IEnumerable<Student>>> GetStudentsByName(string name)
    {
        var students = await _studentService.GetStudentsByName(name);
        return Ok(students);
    }

    [HttpPost]
    public async Task<ActionResult<Student>> RegisterStudent(Student student)
    {
        var newStudent = await _studentService.RegisterStudent(student);
        var calendar = 
        return CreatedAtAction(nameof(GetStudent), new { id = newStudent.id }, newStudent);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateStudent(int id, Student student)
    {
        await _studentService.UpdateStudent(id, student);
        return NoContent();
    }

    [HttpDelete ("{id}")]
    public async Task<ActionResult> DeleteStudent(int id)
    {
        await _studentService.DeleteStudent(id);
        return NoContent();
    }
}

