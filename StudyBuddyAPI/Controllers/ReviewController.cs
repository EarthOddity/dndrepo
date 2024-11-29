using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


[Route("api/[controller]")]
[ApiController]
public class ReviewController(IReviewService _reviewService) : ControllerBase
{
    // private readonly ReviewService _reviewService;

    // public ReviewController(ReviewService reviewService)
    // {
    //     _reviewService = reviewService;
    // }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Review>>> GetAllReviews()
    {
        return Ok(await _reviewService.GetAllReviews());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Review>> GetReviewById(int id)
    {
        var review = await _reviewService.GetReviewById(id);
        if (review == null) return NotFound();

        return Ok(review);
    }

    [HttpGet("author/{authorId}")]
    public async Task<ActionResult<Review>> GetReviewsByAuthor(int authorId)
    {
        var reviews = await _reviewService.GetReviewsByAuthor(authorId);
        if (reviews == null) return NotFound();

        return Ok(reviews);
    }


    [HttpPost]
    public async Task<ActionResult<Review>> AddReview(Review review)
    {
        await _reviewService.AddReview(review);
        return CreatedAtAction(nameof(GetReviewById), new { id = review.id }, review);
    }

    [HttpPut("{id}")]

    public async Task<ActionResult> UpdateReview(int id, Review updatedReview)
    {
        var success = await _reviewService.UpdateReview(id, updatedReview.reviewText, updatedReview.isApproved);
        if (!success) return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]


    public async Task<IActionResult> DeleteReview(int id)
    {
        var success = await _reviewService.DeleteReview(id);
        if (!success) return NotFound();

        return NoContent();
    }

    [HttpGet("reviews/{materialId}")]
    public async Task<ActionResult<IEnumerable<Review>>> GetReviewsByMaterialId(int materialId)
    {
        var reviews = await _reviewService.GetReviewsByMaterialId(materialId);
        return Ok(reviews);
    }
}
