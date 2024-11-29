public class Calendar
{

    public int id { get; set; }

    public Student user { get; set; }

    public List<Event> events { get; set; }

    public Calendar()
    {}
        
    public Calendar(int id, Student user)
    {
        this.id = id;
        this.user = user;
        this.events = new List<Event>(); // initialize to avoid null errors hiuhi
    }




}
