public class Review
{
    public int id { get; set; }
    public string reviewText { get; set; }
    public int authorId { get; set; }
    public Student author { get; set; } 
    public bool isApproved { get; set; }

    public Review(int id, string reviewText, Student author, bool isApproved, int authorId)
    {
        this.id = id;
        this.reviewText = reviewText;
        this.author = author;
        this.authorId = author.id; 
        this.isApproved = isApproved;
    }
}
