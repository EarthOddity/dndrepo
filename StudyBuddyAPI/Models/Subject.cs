using StudyBuddyAPI.Models;

namespace StudyBuddyAPI.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Bachelor[] Bachelors { get; set; }

        public Subject(int id, string name, string description, Bachelor[] bachelors)
        {
            Id = id;
            Name = name;
            Description = description;
            Bachelors = bachelors;
        }
    }
}