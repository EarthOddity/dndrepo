public class Bachelor
{
    public int Id { get; set; }
    public string ProgramName { get; set; }

    public List<Subject> AssociatedSubjects { get; set; } = [];

    public Bachelor()
    {

    }

    public Bachelor(int Id, string ProgramName)
    {
        this.Id = Id;
        this.ProgramName = ProgramName ?? throw new ArgumentNullException(nameof(ProgramName));
        //associatedSubjects = new List<Subject>();
    }
}