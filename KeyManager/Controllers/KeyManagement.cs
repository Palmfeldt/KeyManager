using KeyManager.Application;
using KeyManager.Domain.Models;
using KeyManager.DTOs;
using KeyManager.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace KeyManager.Controllers;

[Tags("Key")]
[ApiController]
[Route("[controller]")]
public class KeyManagement(
    ILogger<KeyManagement> logger,
    IRepository<Key> keyRepository
    ) : ControllerBase
{

    private readonly ILogger<KeyManagement> _logger = logger;
    private IRepository<Key> queryController = keyRepository;

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
            return NotFound("Key not found");

        return Ok(key);
    }

    [HttpPost(Name = "AddKey")]
    public IActionResult Post([FromBody] KeyDto key)
    {

        var keyModel = key.ToModel();

        queryController.Add(keyModel);
        return CreatedAtRoute("GetKeyById", new { id = key.Id }, key);
    }

    [HttpPut("{id}", Name = "UpdateKey")]
    public IActionResult Put(int id, [FromBody] KeyDto key)
    {
        var keyModel = key.ToModel();

        var success = queryController.Update(id, keyModel);
        if (!success)
            return NotFound("Key not found or update failed");

        return Ok("Key updated successfully");
    }

    [HttpDelete("{id}", Name = "DeleteKey")]
    public IActionResult Delete(int id)
    {
        var success = queryController.Delete(id);
        if (!success)
            return NotFound("Key not found");

        return Ok("Key deleted successfully");
    }
}

