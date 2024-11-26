public interface IProfileService
{
    Task<Student> GetStudentProfile(int id);
    Task UpdateStudentProfile(int id, Student student);
    Task DeleteStudentProfile(int id);
    Task<Moderator> GetModeratorProfile(int id);
    Task UpdateModeratorProfile(int id, Moderator moderator);
    Task DeleteModeratorProfile(int id);
}