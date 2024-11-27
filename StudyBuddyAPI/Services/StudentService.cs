using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

public class StudentService (FileContext context) : IStudentService{
    //private static List<Student> studentsList = new List<Student>();
    private readonly FileContext context = context;
    static StudentService()
    {
    }
    public Task<IEnumerable<Student>> GetAllStudents()
    {
        Console.WriteLine("Student removed");
        return Task.FromResult(context.Students.AsEnumerable());
        
    }

    public Task<Student> GetStudentById(int id)
    {
        var student = context.Students.FirstOrDefault(s => s.id == id);
        return Task.FromResult(student);
    }

    public async Task<Student> RegisterStudent(Student student)
    {
        if (string.IsNullOrEmpty(student.name))
        {
            throw new ValidationException("Name cannot be null");
        }

        if (string.IsNullOrEmpty(student.password))
        {
            throw new ValidationException("Password cannot be null");
        }
        if (student.id == 0)
        {
            throw new ValidationException("Id cannot be 0");
        }
        if (string.IsNullOrEmpty(student.email))
        {
            throw new ValidationException("Email is required");
        }
        if (string.IsNullOrEmpty(student.surname))
        {
            throw new ValidationException("Surname is required");
        }
        if (student.phoneNumber == 0)
        {
            throw new ValidationException("Phone number is required");
        }
        if (string.IsNullOrEmpty(student.language))
        {
            throw new ValidationException("Language is required");
        }
        context.Students.Add(student);
        await context.SaveChangesAsync();
        return student;
    }
    public async Task UpdateStudent(int id, [FromBody]Student student)
    {
        var studentToUpdate = context.Students.FirstOrDefault(s => s.id == id);
        if (studentToUpdate != null)
        {
            studentToUpdate.name = student.name;
            studentToUpdate.surname = student.surname;
            studentToUpdate.email = student.email;
            studentToUpdate.phoneNumber = student.phoneNumber;
            studentToUpdate.isTutor = student.isTutor;
            studentToUpdate.language = student.language;
            studentToUpdate.bachelor = student.bachelor;
            await context.SaveChangesAsync();
        }

    }

    public async Task DeleteStudent(int id)
{
    var student = context.Students.FirstOrDefault(student => student.id == id);
    
    if (student != null)
    {
        Console.WriteLine(student.name + " found");
        context.Students.Remove(student);
        Console.WriteLine(student.name + " removed");
        Console.WriteLine("Total students after removal: " + context.Students.Count);
        
        await context.SaveChangesAsync();
        Console.WriteLine("Changes saved to file");
    }   
    else
    {
        Console.WriteLine("Student with id " + id + " not found.");
    }
}

    public Task<IEnumerable<Student>> GetStudentsByName(string name)
    {
        var students = context.Students.Where(s => s.name == name);
        return Task.FromResult(students);
    }
}