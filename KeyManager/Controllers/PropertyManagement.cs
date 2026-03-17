using KeyManager.Application;
using KeyManager.Domain.Models;
using KeyManager.DtoExamples;
using KeyManager.Dtos;
using KeyManager.Mappers;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;

namespace KeyManager.Controllers;

[Tags("Property")]
[ApiController]
[Route("[controller]")]
[SwaggerResponse(StatusCodes.Status404NotFound)]
public class PropertyManagement(
    ILogger<PropertyManagement> logger,
    IRepository<Property> propertyRepository) : ControllerBase
{

    private readonly ILogger<PropertyManagement> _logger = logger;
    private readonly IRepository<Property> propertyRepository = propertyRepository;

    /// <summary>
    /// Get all the properties with their keys
    /// </summary>
    /// <returns></returns>
    [HttpGet(Name = "GetAllProperties")]
    public ActionResult<IEnumerable<Property>> Get()
    {
        var properties = propertyRepository.RetriveAll();
        return Ok(properties);
    }

    [HttpGet("{id}", Name = "GetPropertyById")]
    [SwaggerOperation(
            Summary = "Get a property based on ID",
            Description = "Retrieves a property by its unique identifier. Will include their user and keys."
        )]
    public ActionResult<Property> Get(int id)
    {
        var property = propertyRepository.RetrieveById(id);

        _logger.LogInformation($"Property with id {id} was searched for");

        if (property == null)
        {
            return NotFound("Property not found");
        }

        return Ok(property);
    }

    [HttpPost(Name = "AddProperties")]
    [SwaggerOperation(
            Summary = "Add a property",
            Description = "Adds a new property."
        )]
    [SwaggerRequestExample(typeof(PropertyDto), typeof(CreatePropertyExample))]
    public IActionResult Post([FromBody] PropertyDto newProperty)
    {
        propertyRepository.Add(newProperty.ToModel());
        _logger.LogInformation($"Property with id {newProperty.Id} was created");

        return CreatedAtRoute("GetPropertyById", new { id = newProperty.Id }, newProperty);
    }

    [HttpPut("{id}", Name = "UpdateProperty")]
    [SwaggerOperation(
        Summary = "Modify a property",
        Description = "Modifies a property"
    )]
    public IActionResult Put(int id, [FromBody] PropertyDto property)
    {
        var success = propertyRepository.Update(id, property.ToModel());
        _logger.LogInformation($"Property with id {id} was updated");
        if (!success)
            return NotFound("Property not found or update failed");

        return Ok("Property updated successfully");
    }

    [HttpDelete("{id}", Name = "DeleteProperty")]
    [SwaggerOperation(
        Summary = "Deletes a property",
        Description = "Deletes a property"

    )]
    public IActionResult Delete(int id)
    {
        var success = propertyRepository.Delete(id);
        _logger.LogInformation($"Property with id {id} was deleted");
        if (!success)
            return NotFound("Property not found");

        return Ok("Property deleted successfully");
    }
}

