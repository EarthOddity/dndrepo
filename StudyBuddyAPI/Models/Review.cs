public class Review
{
    public int id { get; set; }
    public string reviewText { get; set; }
    public int authorId { get; set; }
    public Student? author { get; set; }
    public bool isApproved { get; set; }
    public int materialId { get; set; }
    public TeachingMaterial? material { get; set; }

    public Review()
    {
    }

    public Review(int id, string reviewText, Student author, bool isApproved, int authorId, int materialId, TeachingMaterial material)
    {
        this.id = id;
        this.reviewText = reviewText;
        this.author = author;
        this.authorId = authorId;
        this.authorId = authorId;
        this.isApproved = isApproved;
        this.materialId = materialId;
        this.material = material;
        this.materialId = materialId;
        this.material = material;
    }


}