public class Event
{
    public int id { get; set; }
    public int ownerId { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    public List<Student> participants { get; set; }
    public List<TeachingMaterial> materials { get; set; }

    public DateTime startTime { get; set; }
    public DateTime endTime { get; set; }

    public Event()
    {

    }
    public Event(int id, int ownerId, string title, string description, List<Student> participants, List<TeachingMaterial> materials, DateTime startTime, DateTime endTime)
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