public interface IProfileService
{
    Task<Student> GetStudentProfile(int id);
    Task UpdateStudentProfile(int id, Student student);
    Task DeleteStudentProfile(int id);
}