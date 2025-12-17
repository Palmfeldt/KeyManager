using KeyManager.Application;
using KeyManager.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace KeyManager.Controllers;

[Tags("Address")]
[ApiController]
[Route("[controller]")]
[SwaggerResponse(StatusCodes.Status404NotFound)]
public class AddressManagement(
    ILogger<AddressManagement> logger,
    IRepository<Address> addressRepository
    ) : ControllerBase
{

    private readonly ILogger<AddressManagement> _logger = logger;
    private IRepository<Address> queryController = addressRepository;

    /// <summary>
    /// Get all the addresses with their keys
    /// </summary>
    /// <returns></returns>
    [HttpGet(Name = "GetAllAddresses")]
    public ActionResult<IEnumerable<Address>> Get()
    {
        var addresses = queryController.RetriveAll();
        return Ok(addresses);
    }

    [HttpGet("{id}", Name = "GetAddressById")]
    [SwaggerOperation(
            Summary = "Get an address based on ID",
            Description = "Retrieves an address by its unique identifier. Will include their user and keys."
        )]
    public ActionResult<Address> Get(int id)
    {
        var address = queryController.RetrieveById(id);

        _logger.LogInformation($"Address with id {id} was searched for");

        if (address == null)
        {
            return NotFound("Address not found");
        }

        return Ok(address);
    }

    [HttpPost(Name = "AddAddresses")]
    [SwaggerOperation(
            Summary = "Add an address",
            Description = "Adds a new address."
        )]
    public IActionResult Post([FromBody] Address newAddress)
    {
        queryController.Add(newAddress);
        _logger.LogInformation($"Address with id {newAddress.Id} was created");

        return CreatedAtRoute("GetAddressById", new { id = newAddress.Id }, newAddress);
    }

    [HttpPut("{id}", Name = "UpdateAddress")]
    [SwaggerOperation(
        Summary = "Modify an address",
        Description = "Modifies an address"
    )]
    public IActionResult Put(int id, [FromBody] Address address)
    {
        var success = queryController.Update(id, address);
        _logger.LogInformation($"Address with id {id} was updated");
        if (!success)
            return NotFound("Address not found or update failed");

        return Ok("Address updated successfully");
    }

    [HttpDelete("{id}", Name = "DeleteAddress")]
    [SwaggerOperation(
        Summary = "Deletes an address",
        Description = "Deletes an address"

    )]
    public IActionResult Delete(int id)
    {
        var success = queryController.Delete(id);
        _logger.LogInformation($"Address with id {id} was deleted");
        if (!success)
            return NotFound("Address not found");

        return Ok("Address deleted successfully");
    }
}

