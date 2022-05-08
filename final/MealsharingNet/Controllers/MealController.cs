using MealsharingNet.Models;
using Microsoft.AspNetCore.Mvc;

namespace MealsharingNet.Controllers;

[ApiController]
[Route("api/meals")]
public class MealController : ControllerBase
{
    private IMealRepository _repo;

    public MealController(IMealRepository repo)
    {
        _repo = repo;
    }

    [HttpGet("")]
    public async Task<IEnumerable<Meal>> GetMeals([FromQuery]MealSearch mealSearch)
    {
        return await _repo.ListMeals(mealSearch);
    }

    [HttpPost("")]
    public async Task AddMeal([FromBody] Meal meal)
    {
        await _repo.AddMeal(meal);
    }

    [HttpGet("{id}")]
    public async Task <Meal> GetMeal(int id)
    {
        return await _repo.GetMeal(id);
    }
    [HttpDelete("{id}")]
    public async Task DeleteMeal(int id)
    {
        await _repo.DeleteMeal(id);
    }
    [HttpPatch("")]
    public async Task UpdateMeal([FromBody] Meal meal)
    {
        await _repo.UpdateMeal(meal);
    }
}