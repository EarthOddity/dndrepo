
public class SBEvent
{
    public int id { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    //public List<Student> participants { get; set; }
    //public List<TeachingMaterial> materials { get; set; }
    public SBCalendar? calendar { get; set; }
    public int calendarId { get; set; }

    public DateTime startTime { get; set; }
    public DateTime endTime { get; set; }
    public DateTime timestamp { get; set; } =DateTime.UtcNow;

    public SBEvent()
    {

    }
    public SBEvent(int id, string title, string description, DateTime startTime, DateTime endTime)
    {
        this.id = id;
        // initializing non-nullable properties xd
        this.title = title ?? throw new ArgumentNullException(nameof(title));
        this.description = description ?? throw new ArgumentNullException(nameof(description));
        // this.participants = participants ?? new List<Student>();
        // this.materials = materials ?? new List<TeachingMaterial>();
        this.startTime = startTime;
        this.endTime = endTime;
        this.timestamp = DateTime.UtcNow;
    }

}