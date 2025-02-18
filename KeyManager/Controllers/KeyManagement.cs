using KeyManager.Controllers.QueryHandlers;
using KeyManager.Data;
using KeyManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KeyManager.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class KeyManagement(ILogger<KeyManagement> logger, DbContextOptions<AppDbContext> options) : ControllerBase
    {

        private readonly ILogger<KeyManagement> _logger = logger;
        private KeyQueryController queryController = new(options);

        [HttpGet(Name = "GetAllKeys")]
        public ActionResult<IEnumerable<Key>> Get()
        {
            var keys = queryController.RetriveAll();
            return Ok(keys);
        }

        [HttpGet("{id}", Name = "GetKeyById")]
        public ActionResult<Key> Get(int id)
        {
            var key = queryController.RetrieveById(id);
            if (key == null)
            {
                return NotFound("Key not found");
            }
            return Ok(key);
        }

        [HttpPost(Name = "AddKey")]
        public IActionResult Post([FromBody] Key key)
        {
            queryController.Add(key);
            return CreatedAtRoute("GetKeyById", new { id = key.Id }, key);
        }

        [HttpPut("{id}", Name = "UpdateKey")]
        public IActionResult Put(int id, [FromBody] Key key)
        {
            var success = queryController.Update(id, key);
            if (!success)
            {
                return NotFound("Key not found or update failed");
            }
            return Ok("Key updated successfully");
        }

        [HttpDelete("{id}", Name = "DeleteKey")]
        public IActionResult Delete(int id)
        {
            var success = queryController.Delete(id);
            if (!success)
            {
                return NotFound("Key not found");
            }
            return Ok("Key deleted successfully");
        }
    }
}

