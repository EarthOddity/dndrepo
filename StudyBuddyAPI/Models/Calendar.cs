public class Calendar
{

    public int id { get; set; }

    public int studentId { get; set; }

    public List<Event> events { get; set; }

    public Calendar()
    {

    }

    public Calendar(int id, int studentId)
    {
        this.id = id;
        this.studentId = studentId;
        this.events = new List<Event>(); // initialize to avoid null errors hiuhi
    }


}
