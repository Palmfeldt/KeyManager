using KeyManager.Data;
using KeyManager.Models;
using KeyManager.QueryHandlers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KeyManager.Controllers
{

    [Tags("User")]
    [ApiController]
    [Route("[controller]")]
    public class UserManagement(ILogger<KeyManagement> logger, DbContextOptions<AppDbContext> options) : ControllerBase
    {

        private readonly ILogger<KeyManagement> _logger = logger;
        private UserQueryController queryController = new(options);

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
            {
                return NotFound("User not found");
            }
            return Ok(user);
        }

        [HttpPost(Name = "AddUser")]
        public IActionResult Post([FromBody] User newUser)
        {
            queryController.Add(newUser);
            return CreatedAtRoute("GetUserById", new { id = newUser.Id }, newUser);
        }

        [HttpPut("{id}", Name = "UpdateUser")]
        public IActionResult Put(int id, [FromBody] User user)
        {
            var success = queryController.Update(id, user);
            if (!success)
            {
                return NotFound("User not found or update failed");
            }
            return Ok("User updated successfully");
        }

        [HttpDelete("{id}", Name = "DeleteUser")]
        public IActionResult Delete(int id)
        {
            var success = queryController.Delete(id);
            if (!success)
            {
                return NotFound("User not found");
            }
            return Ok("User deleted successfully");
        }
    }
}

