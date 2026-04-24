using Microsoft.AspNetCore.Mvc;
using UserManagementAPI.Models;

namespace UserManagementAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    // In-memory user storage for demo purposes.
    private static readonly List<User> Users =
    [
        new User { Id = 1, Name = "Alice Johnson", Email = "alice@example.com" },
        new User { Id = 2, Name = "Bob Smith", Email = "bob@example.com" }
    ];

    private static int _nextId = 3;

    [HttpGet]
    public ActionResult<IEnumerable<User>> GetAllUsers()
    {
        return Ok(Users);
    }

    [HttpGet("{id}")]
    public ActionResult<User> GetUserById(int id)
    {
        var user = Users.FirstOrDefault(existingUser => existingUser.Id == id);

        if (user is null)
        {
            return NotFound(new { Message = $"User with ID {id} was not found." });
        }

        return Ok(user);
    }

    [HttpPost]
    public ActionResult<User> CreateUser(User user)
    {
        // ApiController handles validation automatically before this action runs.
        user.Id = _nextId++;
        Users.Add(user);

        return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
    }

    [HttpPut("{id}")]
    public ActionResult<User> UpdateUser(int id, User updatedUser)
    {
        var existingUser = Users.FirstOrDefault(user => user.Id == id);

        if (existingUser is null)
        {
            return NotFound(new { Message = $"User with ID {id} was not found." });
        }

        existingUser.Name = updatedUser.Name;
        existingUser.Email = updatedUser.Email;

        return Ok(existingUser);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        var existingUser = Users.FirstOrDefault(user => user.Id == id);

        if (existingUser is null)
        {
            return NotFound(new { Message = $"User with ID {id} was not found." });
        }

        Users.Remove(existingUser);

        return Ok(new { Message = $"User with ID {id} was deleted successfully." });
    }
}
