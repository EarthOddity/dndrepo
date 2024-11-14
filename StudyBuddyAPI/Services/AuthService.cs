using System.ComponentModel.DataAnnotations;

public class AuthService    : IAuthService
{
    private readonly FileContext _context;

    public AuthService(FileContext context)
    {
        _context = context;
    }
    public Task<Student> ValidateStudent (int id, string password)
    {
        Student? existingStudent = _context.Students.FirstOrDefault(s => s.id == id) ?? throw new Exception("Student not found");
        if (!existingStudent.password.Equals(password))
        {
            throw new Exception("Password mismatch");
        }

        return Task.FromResult(existingStudent);

    }
    /*  public async Task RegisterStudent(Student student)
    {
        if (string.IsNullOrEmpty(student.name))
        {
            throw new ValidationException("Name cannot be null");
        }

        if (string.IsNullOrEmpty(student.password))
        {
            throw new ValidationException("Password cannot be null");
        }
        // Do more student info validation here

        // save to persistence instead of list
        _context.Students.Add(student);
        await _context.SaveChangesAsync();
    } */


}