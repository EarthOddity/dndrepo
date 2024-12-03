public class SBEvent
{
    public int id { get; set; }
    public int ownerId { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    public List<Student> participants { get; set; } = new List<Student>();
    public List<TeachingMaterial> materials { get; set; } = new List<TeachingMaterial>();
    public List<SBCalendar> calendars { get; set; } = new List<SBCalendar>();

    public DateTime startTime { get; set; }
    public DateTime endTime { get; set; }

    public SBEvent()
    {

    }
    public SBEvent(int id, int ownerId, string title, string description, List<Student> participants, List<TeachingMaterial> materials, DateTime startTime, DateTime endTime)
    {
        this.id = id;
        this.ownerId = ownerId;
        // initializing non-nullable properties xd
        this.title = title ?? throw new ArgumentNullException(nameof(title));
        this.description = description ?? throw new ArgumentNullException(nameof(description));
        this.participants = participants ?? new List<Student>();
        this.materials = materials ?? new List<TeachingMaterial>();
        this.startTime = startTime;
        this.endTime = endTime;
    }

}