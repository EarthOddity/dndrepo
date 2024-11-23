using System.ComponentModel.DataAnnotations;

public class AuthService    : IAuthServiceAPI
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
    public async Task RegisterStudentAsync(Student student)
    {
        

        _context.Students.Add(student);
        await _context.SaveChangesAsync();
    }


}