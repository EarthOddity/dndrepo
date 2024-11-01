namespace StudyBuddyAPI.Services
{
    public class ReviewService
    {
        private readonly List<Review> reviews = new List<Review>();

        public void AddReview(Review review)
        {
            reviews.Add(review);
            Console.WriteLine($"Added review: {review.ReviewText}");
        }

        public List<Review> GetAllReviews()
        {
            return reviews;
        }

        public Review GetReviewById(int id)
        {
            return reviews.Find(r => r.Id == id); 
        }

        public List<Review> GetReviewsByAuthor(Student author)
        {
            return reviews.FindAll(r => r.Author != null && r.Author.Equals(author));
        }

        public bool UpdateReview(int id, string newReviewText, bool newIsApproved)
        {
            var review = GetReviewById(id);
            if (review == null) return false;

            review.ReviewText = newReviewText;
            review.IsApproved = newIsApproved;
            Console.WriteLine($"Updated review: {id}");
            return true;
        }

        public bool DeleteReview(int id)
        {
            var review = GetReviewById(id);
            if (review == null) return false;

            reviews.Remove(review);
            Console.WriteLine($"Deleted review: {id}");
            return true;
        }
    }
}
