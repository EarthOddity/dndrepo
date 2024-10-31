namespace StudyBuddyAPI.Models
{
    public class Calendar
    {

        public int id { get; set; }

        public int userId { get; set; }

        public List<Event> events { get; set; }

        public Calendar(int id, int userId)
        {
            this.id = id;
            this.userId = userId;
            this.events = new List<Event>(); // initialize to avoid null errors hiuhi
        }




    }
}