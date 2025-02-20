using KeyManager.Data;
using KeyManager.Models;
using KeyManager.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KeyManager.Controllers
{
    [Tags("Address")]
    [ApiController]
    [Route("[controller]")]
    public class AddressManagement(ILogger<KeyManagement> logger, DbContextOptions<AppDbContext> options) : ControllerBase
    {

        private readonly ILogger<KeyManagement> _logger = logger;
        private AddressQueryController queryController = new(options);

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
        public ActionResult<Address> Get(int id)
        {
            var address = queryController.RetrieveById(id);
            if (address == null)
            {
                return NotFound("Address not found");
            }
            return Ok(address);
        }

        [HttpPost(Name = "AddAddresses")]
        public IActionResult Post([FromBody] Address newAddress)
        {
            queryController.Add(newAddress);
            return CreatedAtRoute("GetAddressById", new { id = newAddress.Id }, newAddress);
        }

        [HttpPut("{id}", Name = "UpdateAddress")]
        public IActionResult Put(int id, [FromBody] Address address)
        {
            var success = queryController.Update(id, address);
            if (!success)
            {
                return NotFound("Address not found or update failed");
            }
            return Ok("Address updated successfully");
        }

        [HttpDelete("{id}", Name = "DeleteAddress")]
        public IActionResult Delete(int id)
        {
            var success = queryController.Delete(id);
            if (!success)
            {
                return NotFound("Address not found");
            }
            return Ok("Address deleted successfully");
        }
    }
}

