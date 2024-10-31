namespace StudyBuddyAPI.Models
{
    public class Event
    {
        public int id { get; set; }
        public User owner { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public List<User> participants { get; set; }
        public List<TeachingMaterial> materials { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public Event(int id, User owner, string title, string description, List<User> participants, List<TeachingMaterial> materials, DateTime startTime, DateTime endTime)
        {
            this.id = id;
            // initializing non-nullable properties xd
            this.owner = owner ?? throw new ArgumentNullException(nameof(owner));
            this.title = title ?? throw new ArgumentNullException(nameof(title));
            this.description = description ?? throw new ArgumentNullException(nameof(description));
            this.participants = participants ?? new List<User>();
            this.materials = materials ?? new List<TeachingMaterial>();
            this.StartTime = startTime;
            this.EndTime = endTime;
        }

    }
}
