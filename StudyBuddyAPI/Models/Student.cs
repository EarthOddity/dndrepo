
public class Student : User {
    public bool isTutor { get; set; }
    public string language { get; set; }
    public Bachelor bachelor { get; set; }
    public Calendar calendar { get; set; }

    public Student(int id, string name, string surname, string email, int phoneNumber, bool isTutor, string language, string password): base(id, name, surname, email, phoneNumber, password){
        this.isTutor = isTutor;
        this.language = language;
    }
    public Student(int id, string name, string surname, string email, int phoneNumber, bool isTutor, string language, Bachelor bachelor, string password): base(id, name, surname, email, phoneNumber, password){
        this.isTutor = isTutor;
        this.language = language;
        this.bachelor = bachelor;
    } 
     public Student() : base()
    {   this.isTutor = false;
        this.language = string.Empty;
    }

    }
