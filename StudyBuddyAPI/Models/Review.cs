public class Review
{
    public int Id { get; set; }
    public string ReviewText { get; set; }
    public int AuthorId { get; set; }
    public Student? Author { get; set; }
    public bool IsApproved { get; set; }
    public int MaterialId { get; set; }
    public TeachingMaterial? Material { get; set; }

    public Review() // Default constructor
    {
    }

    // Parameterized constructor without duplicate assignments
    public Review(int Id, string ReviewText, Student Author, bool IsApproved, int AuthorId, int MaterialId, TeachingMaterial Material)
    {
        this.Id = Id;
        this.ReviewText = ReviewText;
        this.Author = Author;
        this.AuthorId = AuthorId;
        this.IsApproved = IsApproved;
        this.MaterialId = MaterialId;
        this.Material = Material;
    }
}
