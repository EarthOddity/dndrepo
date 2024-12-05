public class Bachelor
{
    public int Id { get; set; }
    public string ProgramName { get; set; }

    public List<Subject> AssociatedSubjects { get; set; }

    public Bachelor()
    {

    }

    public Bachelor(int id, string programName)
    {
        this.Id = id;
        this.ProgramName = programName ?? throw new ArgumentNullException(nameof(programName));
        AssociatedSubjects = new List<Subject>();
    }
}