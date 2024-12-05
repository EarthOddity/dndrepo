public class SBCalendar
{
    public int Id { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public Student Owner { get; set; }
    public int OwnerId { get; set; }
    public List<SBEvent> EventList { get; set; } = new List<SBEvent>();

    public SBCalendar()
    {

    }

    public SBCalendar(int id, Student owner)
    {
        this.Id = id;
        this.Owner = owner;
        this.OwnerId = owner.id;

    }


}
