
using System.ComponentModel.DataAnnotations;

public class Student : User
{
    public bool isTutor { get; set; }
    public string language { get; set; }
    public Bachelor bachelor { get; set; } = new Bachelor();
    [Required]
    public SBCalendar calendar { get; set; } = new SBCalendar();


    public List<SavedMaterial> savedMaterials { get; set; } = [];
    public List<Review> reviews { get; set; } = [];

    public Student(int id, string name, string surname, string email, int phoneNumber, bool isTutor, string language, string password) : base(id, name, surname, email, phoneNumber, password)
    {
        this.isTutor = isTutor;
        this.language = language;
        this.calendar = new SBCalendar { Owner = this };
        this.bachelor = new Bachelor();

    }
    public Student(int id, string name, string surname, string email, int phoneNumber, bool isTutor, string language, Bachelor bachelor, string password) : base(id, name, surname, email, phoneNumber, password)
    {
        this.isTutor = isTutor;
        this.language = language;
        this.bachelor = bachelor;
        this.calendar = new SBCalendar { Owner = this };

    }

    public Student() : base()
    {
        this.isTutor = false;
        this.language = string.Empty;
        this.calendar = new SBCalendar { Owner = this };
        this.bachelor = new Bachelor();
    }

}
