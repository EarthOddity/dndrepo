public abstract class User
{
    public int id { get; set; }
    public string name { get; set; }
    public string surname { get; set; }
    public string email { get; set; }
    public int phoneNumber { get; set; }
    public string password { get; set; }

    public User() { }
    public User(int id, string password)
    {
        this.id = id;
        this.password = password;
    }
    public User(int id, string name, string surname, string email, int phoneNumber, string password)
    {
        this.id = id;
        this.name = name;
        this.surname = surname;
        this.email = email;
        this.phoneNumber = phoneNumber;
        this.password = password;
    }
}