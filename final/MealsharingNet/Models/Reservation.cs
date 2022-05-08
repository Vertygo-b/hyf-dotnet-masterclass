namespace MealsharingNet.Models;

public class Reservation
{
    public int ID { get; set; }
    public int Meal_ID { get; set; }
    public string Contact_Name { get; set; }
    public string Contact_Email { get; set; }
    public int Number_of_guests { get; set; }
    public DateTime Created_date { get; set; } = DateTime.Now;
    public string Contact_phonenumber { get; set; }
}