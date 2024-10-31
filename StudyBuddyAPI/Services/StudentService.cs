namespace StudyBuddyAPI.models;
public class StudentService{
    private static List<Student> studentsList = new List<Student>();

    static StudentService(){
    }
      public Task<IEnumerable<Student>> GetAllStudents()
    {
        return Task.FromResult(studentsList.AsEnumerable());
    }

     public Task<Student> GetStudentById(int id)
    {
        var student = studentsList.FirstOrDefault(s => s.id == id);
        return Task.FromResult(student);
    }

    public Task<Student> RegisterStudent(Student student)
    {
        studentsList.Add(student);
        return Task.FromResult(student);
    }
    public Task UpdateStudent(int id, Student student)
    {
        var studentToUpdate = studentsList.FirstOrDefault(s => s.id == id);
        if(studentToUpdate != null){
            studentToUpdate.name = student.name;
            studentToUpdate.surname = student.surname;
            studentToUpdate.email = student.email;
            studentToUpdate.phoneNumber = student.phoneNumber;
            studentToUpdate.isTutor = student.isTutor;
            studentToUpdate.language = student.language;
        }
       
        return Task.CompletedTask;
    }

    public Task DeleteStudent(int id)
    {
        var student = studentsList.FirstOrDefault(s => s.id == id);
        studentsList.Remove(student);
        return Task.CompletedTask;
    }

    public Task<IEnumerable<Student>> GetStudentsByName(string name)
    {
        var students = studentsList.Where(s => s.name == name);
        return Task.FromResult(students);
    }
}