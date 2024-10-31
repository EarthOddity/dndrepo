namespace StudyBuddyAPI.Models
{
    public class Bachelor
    {
        public int id { get; set; }

        public string programName { get; set; }

        public List<Subject> associatedSubjects { get; set; }

        public Bachelor(int bachelorID, string name)
        {
            id = bachelorID;
            programName = name ?? throw new ArgumentNullException(nameof(name));
            associatedSubjects = new List<Subject>();

        }
    }
}