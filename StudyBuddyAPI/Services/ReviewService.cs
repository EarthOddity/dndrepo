
    public class ReviewService
    {
        private readonly List<Review> reviews = new List<Review>();

        public void AddReview(Review review)
        {
            review.Id = reviews.Count > 0 ? reviews.Max(r => r.Id) + 1 : 1;
            reviews.Add(review);
            Console.WriteLine($"Added review with ID {review.Id}: {review.ReviewText}");
        }

        public List<Review> GetAllReviews()
        {
            return reviews;
        }

        public Review GetReviewById(int id)
        {
            return reviews.FirstOrDefault(r => r.Id == id);
        }

        public List<Review> GetReviewsByAuthor(Student author)
        {
            return reviews.Where(r => r.Author != null && r.Author.Equals(author)).ToList();
        }

        public bool UpdateReview(int id, string newReviewText, bool newIsApproved)
        {
            var review = GetReviewById(id);
            if (review == null) return false;

            review.ReviewText = newReviewText;
            review.IsApproved = newIsApproved;
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

