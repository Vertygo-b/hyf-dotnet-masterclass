namespace MealsharingNet.Models;

public class Meal
{
    public int ID { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public DateTime? When { get; set; }
    public int Max_reservations { get; set; }
    public double Price { get; set; }
    public string Img_link { get; set; }
    public DateTime Created_date { get; set; } = DateTime.Now;
    public int? registered_guests { get; set; }
}