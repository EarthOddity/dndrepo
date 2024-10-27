public class Review
{

    public string ReviewText { get; set; }
    public Student Author { get; set; }

    
    public Review(string reviewText, Student author)
    {
        ReviewText = reviewText;
        Author = author;
    }

    public override string ToString()
    {
        return $"Review: {ReviewText}\nAuthor: {Author.Name}";
    }
}