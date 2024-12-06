public abstract class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public int PhoneNumber { get; set; }
    public string Password { get; set; }
    public User() { }
    public User(int Id, string Password)
    {
        this.Id = Id;
        this.Password = Password;
    }
    public User(int Id, string Name, string Surname, string Email, int PhoneNumber, string Password)
    {
        this.Id = Id;
        this.Name = Name;
        this.Surname = Surname;
        this.Email = Email;
        this.PhoneNumber = PhoneNumber;
        this.Password = Password;
    }
}