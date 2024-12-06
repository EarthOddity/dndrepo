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

    public SBCalendar(int id, Student owner)
    {
        this.Id = id;
        this.Student = owner;
        this.StudentId = owner.id;

    }
    public SBCalendar(Student student)
    {
        this.Student = student;
        StudentId = student.id;
    }

}
