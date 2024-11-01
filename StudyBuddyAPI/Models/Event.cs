public class Event
{
    public int id { get; set; }
    public Student owner { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    public List<Student> participants { get; set; }
    public List<TeachingMaterial> materials { get; set; }

    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

    public Event()
    {

    }
    public Event(int id, Student owner, string title, string description, List<Student> participants, List<TeachingMaterial> materials, DateTime startTime, DateTime endTime)
    {
        this.id = id;
        // initializing non-nullable properties xd
        this.owner = owner ?? throw new ArgumentNullException(nameof(owner));
        this.title = title ?? throw new ArgumentNullException(nameof(title));
        this.description = description ?? throw new ArgumentNullException(nameof(description));
        this.participants = participants ?? new List<Student>();
        this.materials = materials ?? new List<TeachingMaterial>();
        this.StartTime = startTime;
        this.EndTime = endTime;
    }

}