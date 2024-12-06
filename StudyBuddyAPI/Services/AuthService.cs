using System.ComponentModel.DataAnnotations;

public class AuthService : IAuthServiceAPI
{
    private readonly DatabaseContext _context;

    public AuthService(DatabaseContext context)
    {
        _context = context;
    }
    public Task<Student> ValidateStudent(int Id, string Password)
    {
        Student? existingStudent = _context.Students.FirstOrDefault(s => s.Id == Id) ?? throw new Exception("Student not found");
        if (!existingStudent.Password.Equals(Password))
        {
            throw new Exception("Password mismatch");
        }

        return Task.FromResult(existingStudent);
    }
    public Task<Moderator> ValidateModerator(int Id, string Password)
    {
        Moderator? existingModerator = _context.Moderators.FirstOrDefault(m => m.Id == Id) ?? throw new Exception("Moderator not found");
        if (!existingModerator.Password.Equals(Password))
        {
            throw new Exception("Password mismatch");
        }

        return Task.FromResult(existingModerator);

    }
    public async Task RegisterStudentAsync(Student student)
    {


        _context.Students.Add(student);
        await _context.SaveChangesAsync();
    }


}