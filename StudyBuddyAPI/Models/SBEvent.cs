public class SBEvent
{
    public int Id { get; set; }
    public int OwnerId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public List<SBCalendar> Calendars { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public DateTime Timestamp { get; set; }

    public SBEvent()
    {

    }
    public SBEvent(int id, int ownerId, string title, string description, List<TeachingMaterial> materials, DateTime startTime, DateTime endTime)
    {
        this.Id = id;
        this.OwnerId = ownerId;
        this.Title = title ?? throw new ArgumentNullException(nameof(title));
        this.Description = description ?? throw new ArgumentNullException(nameof(description));
        this.StartTime = startTime;
        this.EndTime = endTime;
        this.Timestamp = DateTime.UtcNow;

    }

}