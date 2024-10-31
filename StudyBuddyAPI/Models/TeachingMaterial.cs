public class TeachingMaterial
{
    public string Title { get; set; }
    public string Description { get; set; }
    public Student Author { get; set; }
    public bool IsApproved { get; set; }

    public TeachingMaterial(string title, string description, Student author, bool isApproved)
    {
        Title = title;
        Description = description;
        Author = author;
        IsApproved = isApproved;
    }
}