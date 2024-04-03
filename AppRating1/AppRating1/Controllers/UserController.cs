using AppRating1.Controllers.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    public static List<User> _users = new List<User>();

    // GET: api/user
    [HttpGet]
    public ActionResult<IEnumerable<User>> GetUsers()
    {
        return _users;
    }

    // GET: api/user/{id}
    [HttpGet("{id}")]
    public ActionResult<User> GetUser(Guid id)
    {
        var user = _users.FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
            return NotFound();
        }
        return user;
    }

    // POST: api/user
    [HttpPost]
    public ActionResult<User> AddUser(User user)
    {
        _users.Add(user);
        return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
    }

    // PUT: api/user/{id}
    [HttpPut("{id}")]
    public IActionResult UpdateUser(Guid id, User user)
    {
        try
        {
            var existingUser = _users.FirstOrDefault(u => u.Id == id);
            if (existingUser == null)
            {
                return NotFound();
            }
            existingUser.Username = user.Username;            
            return Ok(existingUser);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // DELETE: api/user/{id}
    [HttpDelete("{id}")]
    public IActionResult DeleteUser(Guid id)
    {
        var existingUser = _users.FirstOrDefault(u => u.Id == id);
        if (existingUser == null)
        {
            return NotFound();
        }
        _users.Remove(existingUser);
        return NoContent();
    }
}
