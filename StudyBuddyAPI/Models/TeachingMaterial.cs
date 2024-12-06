public class TeachingMaterial
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

    public Student? Author { get; set; }

    public bool IsApproved { get; set; }
    public int SubjectId { get; set; }
    public Subject? Subject { get; set; }
    public List<SavedMaterial> SavedMaterials { get; set; } = [];
    public List<Review> Reviews { get; set; } = [];

    public TeachingMaterial()
    {
    }
    public TeachingMaterial(int Id, string Title, string Description, Student Author, bool IsApproved)
    {
        this.Id = Id;
        this.Title = Title;
        this.Description = Description;
        this.Author = Author;
        this.IsApproved = IsApproved;
    }
}