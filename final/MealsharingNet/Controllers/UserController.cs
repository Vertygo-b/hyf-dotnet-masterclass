using MealsharingNet.Models;
using Microsoft.AspNetCore.Mvc;

namespace MealsharingNet.Controllers;

[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet("")]
    public async Task<IEnumerable<User>> GetAll()
    {
        return await _userRepository.GetUsers();
    }

    [HttpGet("{id}")]
    public async Task<User> GetUserById(int id)
    {
        return await _userRepository.GetUserByID(id);
    }

    [HttpDelete("{id}")]
    public async Task DeleteUser(int id)
    {
        await _userRepository.DeleteUserById(id);
    }
    [HttpPost("AddUser")]
    public async Task AddUser(User user)
    {
        await _userRepository.AddUser(user);
    }
}