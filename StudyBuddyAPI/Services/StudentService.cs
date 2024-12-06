using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

public class StudentService (DatabaseContext context) : IStudentService{
    //private static List<Student> studentsList = new List<Student>();
    private readonly DatabaseContext context = context;
    static StudentService()
    {
    }
    public Task<IEnumerable<Student>> GetAllStudents()
    {
        return Task.FromResult(context.Students.AsEnumerable());
        
    }

    public Task<Student> GetStudentById(int id)
    {
        var student = context.Students.FirstOrDefault(s => s.Id == id);
        return Task.FromResult(student);
    }

    public async Task<Student> RegisterStudent(Student student)
    {
        if (string.IsNullOrEmpty(student.Name))
        {
            throw new ValidationException("Name cannot be null");
        }

        if (string.IsNullOrEmpty(student.Password))
        {
            throw new ValidationException("Password cannot be null");
        }
        if (string.IsNullOrEmpty(student.Email))
        {
            throw new ValidationException("Email is required");
        }
        if (string.IsNullOrEmpty(student.Surname))
        {
            throw new ValidationException("Surname is required");
        }
        if (student.PhoneNumber == 0)
        {
            throw new ValidationException("Phone number is required");
        }
        if (string.IsNullOrEmpty(student.Language))
        {
            throw new ValidationException("Language is required");
        }
        await context.Students.AddAsync(student);
        await context.SaveChangesAsync();
        return student;
    }
    public async Task UpdateStudent(int id, [FromBody]Student student)
    {
        var studentToUpdate = context.Students.FirstOrDefault(s => s.Id == id);
        if (studentToUpdate != null)
        {
            studentToUpdate.Name = student.Name;
            studentToUpdate.Surname = student.Surname;
            studentToUpdate.Email = student.Email;
            studentToUpdate.PhoneNumber = student.PhoneNumber;
            studentToUpdate.IsTutor = student.IsTutor;
            studentToUpdate.Language = student.Language;
           // studentToUpdate.bachelor = student.bachelor;
            await context.SaveChangesAsync();
        }

    }

    public async Task DeleteStudent(int id)
{
    var student = context.Students.FirstOrDefault(student => student.Id == id);
    
    if (student != null)
    {
        Console.WriteLine(student.Name + " found");
        context.Students.Remove(student);
        Console.WriteLine(student.Name + " removed");
       // Console.WriteLine("Total students after removal: " + context.Students.Count);
        
        await context.SaveChangesAsync();
        Console.WriteLine("Changes saved to file");
    }   
    else
    {
        Console.WriteLine("Student with id " + id + " not found.");
    }
}

    public async Task<IEnumerable<Student>> GetStudentsByName(string name)
    {
        var students = await context.Students.Where(s => s.Name == name).ToListAsync();
        return students;
    }
}