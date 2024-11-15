public class ReviewService(FileContext context) : IReviewService
{
    // private readonly List<Review> reviews = new List<Review>();

    private readonly FileContext context = context;
    static ReviewService()
    {
    }
    public async Task<Review> AddReview(Review review)
    {
        context.Reviews.Add(review);
        await context.SaveChangesAsync();
        return review;
    }

    public Task<IEnumerable<Review>> GetAllReviews()
    {
        return Task.FromResult(context.Reviews.AsEnumerable());
    }

    public Task<Review> GetReviewById(int id)
    {
        var review = context.Reviews.FirstOrDefault(r => r.id == id);
        return Task.FromResult(review);
    }

    public  Task<List<Review>> GetReviewsByAuthor(int authorId) // Simplified
    {
        var reviews =  context.Reviews;
        var filteredReviews = reviews.Where(r => r.authorId == authorId).ToList();
        return Task.FromResult(filteredReviews);
    }

    public async Task<bool> UpdateReview(int id, string reviewText, bool isApproved)
    {
        var reviewToUpdate = context.Reviews.FirstOrDefault(r => r.id == id);
        if (reviewToUpdate != null)
        {
            reviewToUpdate.reviewText = reviewText;
            reviewToUpdate.isApproved = isApproved;
            await context.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public async Task<bool> DeleteReview(int id)
    {
        var review = context.Reviews.FirstOrDefault(review => review.id == id);
        if (review != null)
        {
            context.Reviews.Remove(review);
            await context.SaveChangesAsync();
            return true;
        }
        return false;
    }

}
