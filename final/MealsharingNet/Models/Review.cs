namespace MealsharingNet.Models;

public class Review
{
    public int ID { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int Meal_ID { get; set; }
    public int Stars { get; set; }
    public DateTime Created_date { get; set; } = DateTime.Now;
}