using System.Text.Json.Serialization;

public class SBCalendar
{

    public int id { get; set; }

    public int studentId { get; set; }

    public List<SBEvent>? events { get; set; }
    [JsonIgnore]
    public Student? student { get; set; }

    public SBCalendar()
    {

    }

    public SBCalendar(int id, int studentId)
    {
        this.id = id;
        this.studentId = studentId;
        this.events = new List<SBEvent>(); // initialize to avoid null errors hiuhi
    }
    public SBCalendar(Student student){
        this.student = student;
        studentId = student.id;
    }

}
