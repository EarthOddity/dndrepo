
using Microsoft.AspNetCore.Mvc;
using StudyBuddyAPI.models;
using System.Collections.Generic;

namespace StudyBuddyAPI;

[ApiController]
[Route("api/[controller]")]

public class StudentController: ControllerBase{
    private readonly StudentService _studentService;

    public StudentController(StudentService studentService){
        _studentService = studentService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Student>>> GetStudents(){
        var students = await _studentService.GetAllStudents();
        return Ok(students);   
         
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Student>> GetStudent(int id){
        var student = await _studentService.GetStudentById(id);
        if(student == null){
            return NotFound();
        }
        return Ok(student);
    }

<<<<<<< HEAD
=======
    [HttpGet("name/{name}")]
    public async Task<ActionResult<IEnumerable<Student>>> GetStudentsByName(string name){
        var students = await _studentService.GetStudentsByName(name);
        return Ok(students);
    }

>>>>>>> Sergio
    [HttpPost]
    public async Task<ActionResult<Student>> RegisterStudent(Student student){
        var newStudent = await _studentService.RegisterStudent(student);
        return CreatedAtAction(nameof(GetStudent), new {id = newStudent.id}, newStudent);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateStudent(int id, Student student){
        await _studentService.UpdateStudent(id, student);
        return NoContent();
    }
<<<<<<< HEAD
=======

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteStudent(int id){
        await _studentService.DeleteStudent(id);
        return NoContent();
    }
>>>>>>> Sergio
}

