
public class SBEvent
{
    public int Id { get; set; }
    public int OwnerId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    //public List<Student> participants { get; set; }
    //public List<TeachingMaterial> materials { get; set; }
    public SBCalendar? Calendar { get; set; }
    public int CalendarId { get; set; }

    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;

    public SBEvent()
    {

    }
    public SBEvent(int Id, string Title, string Description, List<Student> Participants, List<TeachingMaterial> Materials, DateTime StartTime, DateTime EndTime
    )
    {
        this.Id = Id;
        // initializing non-nullable properties xd
        this.Title = Title ?? throw new ArgumentNullException(nameof(Title));
        this.Description = Description ?? throw new ArgumentNullException(nameof(Description));
        //this.participants = participants ?? new List<Student>();
        // this.materials = materials ?? new List<TeachingMaterial>();
        this.StartTime = StartTime;
        this.EndTime = EndTime;
        this.Timestamp = DateTime.UtcNow;
    }

}