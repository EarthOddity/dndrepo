using System.Text.Json.Serialization;

public class SBCalendar
{
    public int Id { get; set; }

    public int StudentId { get; set; }

    public List<SBEvent>? Events { get; set; }
    [JsonIgnore]
    public Student? Student { get; set; }

    public SBCalendar()
    {

    }

    public SBCalendar(int Id, int StudentId)
    {
        this.Id = Id;
        this.StudentId = StudentId;
        this.Events = new List<SBEvent>(); // initialize to avoid null errors hiuhi
    }
    public SBCalendar(Student Student){
        this.Student = Student;
        StudentId = Student.Id;
    }

}
