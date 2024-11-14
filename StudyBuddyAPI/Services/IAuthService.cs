public interface IAuthService
{
    //Task<User> Register(User user);
    Task<Student> ValidateStudent (int id, string password);
}