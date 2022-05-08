using MealsharingNet.Models;
using Microsoft.AspNetCore.Mvc;

namespace MealsharingNet.Controllers;

[ApiController]
[Route("api/reviews")]
public class ReviewController : ControllerBase
{
    private IReviewRepository _repo;

    public ReviewController(IReviewRepository repo)
    {
        _repo = repo;
    }

    [HttpGet("")]
    public async Task<IEnumerable<Review>> ListReviews()
    {
        return await _repo.ListReviews();
    }

    [HttpPost("")]
    public async Task AddReview([FromBody] Review review)
    {
        await _repo.AddReview(review);
    }

    [HttpGet("{id}")]
    public async Task <List<Review>> GetMealReviews(int id)
    {
        return await _repo.GetMealReviews(id);
    }
    [HttpDelete("{id}")]
    public async Task DeleteReview(int id)
    {
        await _repo.DeleteReview(id);
    }
    [HttpPatch("")]
    public async Task UpdateReview([FromBody] Review review)
    {
        await _repo.UpdateReview(review);
    }
}