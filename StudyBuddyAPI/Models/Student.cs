
using System.ComponentModel.DataAnnotations;

public class Student : User
{
    public bool IsTutor { get; set; }
    public string Language { get; set; }
    public Bachelor? Bachelor { get; set; }
    public int? BachelorId { get; set; }
    public SBCalendar? Calendar { get; set; }

    public List<SavedMaterial> SavedMaterials { get; set; } = [];
    public List<Review> Reviews { get; set; } = [];

    public Student(int Id, string Name, string Surname, string Email, int PhoneNumber, bool IsTutor, string Language, string Password) : base(Id, Name, Surname, Email, PhoneNumber, Password)
    {
        this.IsTutor = IsTutor;
        this.Language = Language;

    }
    public Student(int Id, string Name, string Surname, string Email, int PhoneNumber, bool IsTutor, string Language, Bachelor Bachelor, string Password) : base(Id, Name, Surname, Email, PhoneNumber, Password)
    {
        this.IsTutor = IsTutor;
        this.Language = Language;
        this.Bachelor = Bachelor;

    }

    public Student() : base()
    {
        this.IsTutor = false;
        this.Language = string.Empty;
    }

}
