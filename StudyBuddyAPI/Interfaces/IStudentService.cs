public interface IStudentService
{
    Task<IEnumerable<Student>> GetAllStudents();
    Task<Student> GetStudentById(int id);
    Task<Student> RegisterStudent(Student student);
    Task UpdateStudent(int id, Student student);
    Task DeleteStudent(int id);
    Task<IEnumerable<Student>> GetStudentsByName(string name);
}