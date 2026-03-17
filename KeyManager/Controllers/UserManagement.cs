using KeyManager.Application;
using KeyManager.Domain.Models;
using KeyManager.Dtos;
using KeyManager.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace KeyManager.Controllers;

[Tags("User")]
[ApiController]
[Route("[controller]")]
public class UserManagement(ILogger<KeyManagement> logger, IRepository<User> userRepository) : ControllerBase
{

    private readonly ILogger<KeyManagement> _logger = logger;
    private IRepository<User> queryController = userRepository;

    /// <summary>
    /// Get all the users
    /// </summary>
    /// <returns></returns>
    [HttpGet(Name = "GetAllUsers")]
    public ActionResult<IEnumerable<User>> Get()
    {
        var users = queryController.RetriveAll();
        return Ok(users);
    }

    [HttpGet("{id}", Name = "GetUserById")]
    public ActionResult<User> Get(int id)
    {
        var user = queryController.RetrieveById(id);
        if (user == null)
            return NotFound("User not found");

        return Ok(user);
    }

    [HttpPost(Name = "AddUser")]
    public IActionResult Post([FromBody] UserDto newUser)
    {
        queryController.Add(newUser.ToModel());
        return CreatedAtRoute("GetUserById", new { id = newUser.Id }, newUser);
    }

    [HttpPut("{id}", Name = "UpdateUser")]
    public IActionResult Put(int id, [FromBody] UserDto user)
    {
        var success = queryController.Update(id, user.ToModel());
        if (!success)
            return NotFound("User not found or update failed");

        return Ok("User updated successfully");
    }

    [HttpDelete("{id}", Name = "DeleteUser")]
    public IActionResult Delete(int id)
    {
        var success = queryController.Delete(id);
        if (!success)
            return NotFound("User not found");

        return Ok("User deleted successfully");
    }
}

