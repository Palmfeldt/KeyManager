using KeyManager.Application;
using KeyManager.Domain.Models;
using KeyManager.Dtos;
using KeyManager.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace KeyManager.Controllers;

[Tags("Resident")]
[ApiController]
[Route("[controller]")]
public class ResidentManagement(
    ILogger<ResidentManagement> logger, 
    IRepository<Resident> ResidentRepository) : ControllerBase
{

    private readonly ILogger<ResidentManagement> _logger = logger;
    private IRepository<Resident> queryController = ResidentRepository;

    /// <summary>
    /// Get all the Residents
    /// </summary>
    /// <returns></returns>
    [HttpGet(Name = "GetAllResidents")]
    public ActionResult<IEnumerable<Resident>> Get()
    {
        var Residents = queryController.RetriveAll();
        return Ok(Residents);
    }

    [HttpGet("{id}", Name = "GetResidentById")]
    public ActionResult<Resident> Get(int id)
    {
        var Resident = queryController.RetrieveById(id);
        if (Resident == null)
            return NotFound("Resident not found");

        return Ok(Resident);
    }

    [HttpPost(Name = "AddResident")]
    public IActionResult Post([FromBody] ResidentDto newResident)
    {
        queryController.Add(newResident.ToModel());
        return CreatedAtRoute("GetResidentById", new { id = newResident.Id }, newResident);
    }

    [HttpPut("{id}", Name = "UpdateResident")]
    public IActionResult Put(int id, [FromBody] ResidentDto Resident)
    {
        var success = queryController.Update(id, Resident.ToModel());
        if (!success)
            return NotFound("Resident not found or update failed");

        return Ok("Resident updated successfully");
    }

    [HttpDelete("{id}", Name = "DeleteResident")]
    public IActionResult Delete(int id)
    {
        var success = queryController.Delete(id);
        if (!success)
            return NotFound("Resident not found");

        return Ok("Resident deleted successfully");
    }
}

