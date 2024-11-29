public interface IReviewService
{
    Task<IEnumerable<Review>> GetAllReviews();
    Task<Review> GetReviewById(int id);
    Task<List<Review>> GetReviewsByAuthor(int authorId);
    Task<Review> AddReview(Review review);
    Task<bool> UpdateReview(int id, string reviewText, bool isApproved);
    Task<bool> DeleteReview(int id);
    Task<IEnumerable<Review>> GetReviewsByMaterialId(int materialId);

}