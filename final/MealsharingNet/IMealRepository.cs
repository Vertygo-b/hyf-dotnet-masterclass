using MealsharingNet.Models;

namespace MealsharingNet;

public interface IMealRepository
{
    Task<IEnumerable<Meal>> ListMeals(MealSearch mealSearch);
    Task AddMeal(Meal meal);
    Task<Meal> GetMeal(int id);
    Task DeleteMeal(int id);
    Task UpdateMeal(Meal meal);
}