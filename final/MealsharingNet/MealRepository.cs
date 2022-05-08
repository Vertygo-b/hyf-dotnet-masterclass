using MySql.Data.MySqlClient;
using Dapper;
using MealsharingNet;
using MealsharingNet.Models;

public class MealRepository : IMealRepository
{
    private MySqlConnection _connection;
    private readonly ILogger<MealRepository> _logger;

    public MealRepository(ILogger<MealRepository> logger)
    {
        _connection = new MySqlConnection(Shared.ConnectionString);
        _logger = logger;
    }
    public async Task AddMeal(Meal meal)
    {
        await _connection.ExecuteAsync("insert into meals (title, description, location, max_reservations, price, img_link) values (@Title, @Description, @Location, @Max_reservations, @Price, @Img_link)", meal);
    }

    public async Task DeleteMeal(int id)
    {
        await _connection.ExecuteAsync(@"DELETE FROM meals WHERE Id = @Id", new { Id = id });
    }

    public async Task<Meal> GetMeal(int id)
    {
        var meal = await _connection.QueryFirstAsync<Meal>("select * from meals where id=@mealId", new { mealId = id });
        return meal;
    }

    public async Task<IEnumerable<Meal>> ListMeals(MealSearch mealSearch)
    {
        var query = "select * from meals";

        if(mealSearch?.AvailableReservations==true)
        {
            if(!string.IsNullOrWhiteSpace(mealSearch?.Title))
            {
                if(mealSearch?.MaxPrice>0)
                {
                    query="SELECT meals.*, sum(reservations.number_of_guests) as registered_guests FROM meals inner join reservations on meals.id = reservations.meal_id where title like @title and price < @MaxPrice group By meals.id having max_reservations > registered_guests";

                }
                else
                {
                    query="SELECT meals.*, sum(reservations.number_of_guests) as registered_guests FROM meals inner join reservations on meals.id = reservations.meal_id where title like @title group By meals.id having max_reservations > registered_guests";
                }
            }
            else
            {
                query=" SELECT meals.*, sum(reservations.number_of_guests) as registered_guests FROM meals inner join reservations on meals.id = reservations.meal_id group By meals.id having max_reservations > registered_guests";
            }
        }
        else if(mealSearch?.MaxPrice>0)
        {
            query="SELECT * FROM meals where price < @MaxPrice";
        }
        else if(!string.IsNullOrWhiteSpace(mealSearch?.Title))
        {
            if(mealSearch?.MaxPrice>0)
            {
                query="SELECT * FROM meals where title like @title and price < @MaxPrice";
            }
            else
            {
                query="SELECT * FROM meals where title like @title";
            }
        }

        _logger.LogInformation("Query is {Query}", query);
        
        var meals = await _connection.QueryAsync<Meal>(query, new{ Title = "%" + mealSearch.Title + "%" , MaxPrice =  mealSearch.MaxPrice, AvailableReservation = mealSearch.AvailableReservations });

        return meals;
    }

    public async Task UpdateMeal(Meal meal)
    {
        await _connection.ExecuteAsync("UPDATE meals SET title=@title, description=@description, location=@location, max_reservations=@max_reservations, price=@price, created_date=@created_date, img_link=@Img_link WHERE id = @ID", meal);
    }
}