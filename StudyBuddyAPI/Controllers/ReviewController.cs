using Microsoft.AspNetCore.Mvc;
using StudyBuddyAPI.Services;

namespace StudyBuddyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly ReviewService _reviewService;

        public ReviewController(ReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet]
        public ActionResult<List<Review>> GetAllReviews()
        {
            return Ok(_reviewService.GetAllReviews());
        }

        [HttpGet("{id}")]
        public ActionResult<Review> GetReviewById(int id)
        {
            var review = _reviewService.GetReviewById(id);
            if (review == null) return NotFound();

            return Ok(review);
        }

        [HttpGet("Author/{authorId}")]
        public ActionResult<List<Review>> GetReviewsByAuthor(int authorId)
        {
            var reviews = _reviewService.GetReviewsByAuthor(new Student { Id = authorId });
            return Ok(reviews);
        }

        [HttpPost]
        public ActionResult<Review> AddReview(Review review)
        {
            _reviewService.AddReview(review);
            return CreatedAtAction(nameof(GetReviewById), new { id = review.Id }, review);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateReview(int id, [FromBody] Review updatedReview)
        {
            var success = _reviewService.UpdateReview(id, updatedReview.ReviewText, updatedReview.IsApproved);
            if (!success) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteReview(int id)
        {
            var success = _reviewService.DeleteReview(id);
            if (!success) return NotFound();

            return NoContent();
        }
    }
}
