public interface IAuthServiceAPI
{
    //Task<User> Register(User user);
    Task<Student> ValidateStudent (int id, string password);
    Task<Moderator> ValidateModerator (int id, string password);
    Task RegisterStudentAsync(Student student);
}