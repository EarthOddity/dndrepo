public class ReviewService
{
    private readonly List<Review> reviews = new List<Review>();

    public void AddReview(Review review)
    {
        review.id = reviews.Count > 0 ? reviews.Max(r => r.id) + 1 : 1;
        reviews.Add(review);
        Console.WriteLine($"Added review with ID {review.id}: {review.reviewText}");
    }

    public List<Review> GetAllReviews()
    {
        return reviews;
    }

    public Review GetReviewById(int id)
    {
        return reviews.FirstOrDefault(r => r.id == id);
    }

    public List<Review> GetReviewsByAuthor(int authorId) // Simplified
    {
        return reviews.Where(r => r.authorId == authorId).ToList();
    }

    public bool UpdateReview(int id, string newReviewText, bool newIsApproved)
    {
        var review = GetReviewById(id);
        if (review == null) return false;

        review.reviewText = newReviewText;
        review.isApproved = newIsApproved;
        Console.WriteLine($"Updated review with ID {id}");
        return true;
    }

    public bool DeleteReview(int id)
    {
        var review = GetReviewById(id);
        if (review == null) return false;

        reviews.Remove(review);
        Console.WriteLine($"Deleted review with ID {id}");
        return true;
    }
}
