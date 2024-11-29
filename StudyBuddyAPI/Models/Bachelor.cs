public class Bachelor
{
    public int id { get; set; }
    public string programName { get; set; }

    public List<Subject> associatedSubjects { get; set; }
    public List<Student> students { get; set; }

    public Bachelor()
    {

    }

    public Bachelor(int id, string programName)
    {
        this.id = id;
        this.programName = programName ?? throw new ArgumentNullException(nameof(programName));
        associatedSubjects = new List<Subject>();
    }
}
