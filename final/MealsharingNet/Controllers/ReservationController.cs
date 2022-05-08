using MealsharingNet.Models;
using Microsoft.AspNetCore.Mvc;

namespace MealsharingNet.Controllers;

[ApiController]
[Route("api/reservations")]
public class ReservationController : ControllerBase
{
    private IReservationRepository _repo;

    public ReservationController(IReservationRepository repo)
    {
        _repo = repo;
    }

    [HttpGet("")]
    public async Task<IEnumerable<Reservation>> GetReservations()
    {
        return await _repo.ListReservations();
    }

    [HttpPost("")]
    public async Task AddReservation([FromBody] Reservation reservation)
    {
        await _repo.AddReservation(reservation);
    }

    [HttpGet("{id}")]
    public async Task<List<Reservation>> GetMealReservations(int id)
    {
        return await _repo.GetMealReservations(id);
    }
    [HttpDelete("{id}")]
    public async Task DeleteReservation(int id)
    {
        await _repo.DeleteReservation(id);
    }
    [HttpPatch("")]
    public async Task UpdateMeal([FromBody] Reservation reservation)
    {
        await _repo.UpdateReservation(reservation);
    }
}