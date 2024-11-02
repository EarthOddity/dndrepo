public class StudentService (FileContext context){
    //private static List<Student> studentsList = new List<Student>();
    private readonly FileContext context = context;
    static StudentService()
    {
    }
    public Task<IEnumerable<Student>> GetAllStudents()
    {
        
        return Task.FromResult(context.Students.AsEnumerable());
    }

    public Task<Student> GetStudentById(int id)
    {
        var student = context.Students.FirstOrDefault(s => s.id == id);
        return Task.FromResult(student);
    }

    public async Task<Student> RegisterStudent(Student student)
    {
        context.Students.Add(student);
        await context.SaveChangesAsync();
        return student;
    }
    public async Task UpdateStudent(int id, Student student)
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
            await context.SaveChangesAsync();
        }

    }

    public async Task DeleteStudent(int id)
    {
        var student = context.Students.FirstOrDefault(s => s.id == id);
        if (student == null)
        {
           context.Students.Remove(student);
           await context.SaveChangesAsync();
        }
        
    }

    public Task<IEnumerable<Student>> GetStudentsByName(string name)
    {
        var students = context.Students.Where(s => s.name == name);
        return Task.FromResult(students);
    }
}