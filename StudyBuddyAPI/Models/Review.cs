public class Review
{
    public int Id { get; set; }
    public string ReviewText { get; set; }
    public Student Author { get; set; }

    public bool IsApproved { get; set; }

    
    public Review(int id, string reviewText, Student author, bool isApproved)
    {
        Id = id;
        ReviewText = reviewText;
        Author = author;
        IsApproved = isApproved;
    }
}
